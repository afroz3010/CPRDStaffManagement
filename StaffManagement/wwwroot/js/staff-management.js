$(document).ready(function () {
    const staffListContainer = $('#staffListContainer');
    const staffDetailsContainer = $('#staffDetailsContainer');

    // Enable/disable Staff Active dropdown based on Grant selection
    $('#grantDropdown').change(function () {
        const isGrantSelected = $(this).val() !== "";
        $('#staffActiveDropdown').prop('disabled', !isGrantSelected);

        if (!isGrantSelected) {
            $('#staffActiveDropdown').val('');
            clearStaffList();
        }
    });

    // Handle both dropdowns' changes
    $('#grantDropdown, #staffActiveDropdown').change(function () {
        clearStaffDetails();    
        const selectedGrant = $('#grantDropdown').val();
        const isActive = $('#staffActiveDropdown').val();

        if (selectedGrant && isActive) {
            loadStaffList(selectedGrant, isActive);
        }
        else {
            clearStaffList();
        }
    });

    function loadStaffList(selectedGrant, isActive) {
        showLoading(staffListContainer);

        $.ajax({
            url: '/Staff/FilterStaff',
            type: 'GET',
            data: {
                selectedGrant: selectedGrant,
                isStaffActive: isActive
            },
            success: function (result) {
                staffListContainer.html(result);
                initializeStaffSelection();
            },
            error: function () {
                showError(staffListContainer);
            }
        });
    }

    function loadStaffDetails(staffId) {
        const selectedGrant = $('#grantDropdown').val();

        $.ajax({
            url: '/Staff/GetStaffDetails',
            type: 'GET',
            data: { staffId: staffId, selectedGrant: selectedGrant },
            success: function (result) {
                populateStaffDetails(result);
            },
            error: function () {
                showError('#staffDetailsForm');
            }
        });
    }

    function populateStaffDetails(staff) {
        console.log(staff)
        $('#staffName').val(staff.name);
        $('#staffEmail').val(staff.email);
        $('#startDate').val(formatDate(staff.grant.startDate));
        $('#endDate').val(formatDate(staff.grant.endDate));
        $('#certificationDate').val(formatDate(staff.certificationDate));

        // Enable form fields
        $('#staffDetailsForm input').prop('disabled', false);
    }

    function initializeStaffSelection() {
        $('.staff-item').click(function () {
            $('.staff-item').removeClass('active');
            $(this).addClass('active');

            const staffId = $(this).data('staff-id');
            loadStaffDetails(staffId);
        });
    }

    function showLoading(container) {
        $(container).html(`
            <div class="text-center p-3">
                <div class="spinner-border text-primary" role="status">
                    <span class="visually-hidden">Loading...</span>
                </div>
            </div>
        `);
    }

    function showError(container) {
        $(container).html(`
            <div class="alert alert-danger m-3">
                Error loading data. Please try again.
            </div>
        `);
    }

    function clearStaffList() {
        staffListContainer.html(`
            <div class="list-group-item text-muted">
                Select filters to view staff
            </div>
        `);
        clearStaffDetails();
    }

    function clearStaffDetails() {
        $('#staffDetailsForm input').val('').prop('disabled', true);
    }

    function formatDate(dateString) {
        if (!dateString) return '';
        return new Date(dateString).toISOString().split('T')[0];
    }
});