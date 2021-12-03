$(document).ready(function () {

    $('#btnCreateStudent').on('click', function () {
        const data = getFormData('form#create');
        sendRequestWithData('api/student/create', 'PUT', data, reloadOnSuccess, Error);
    })


    $('div.modal #btnEditStudent').on('click', function () {
        const data = getFormData('form#editStudentForm');
        sendRequestWithData('api/student/edit', 'PATCH', data, reloadOnSuccess, error);
    })


    $('table #btnEditStudent').on('click', function () {
        event.preventDefault();
        const studentId = $(this).attr("studentId");
        getDataToModalForm(`api/student/${studentId}`, '#editStudentForm', '#editStudentModal');
    })
})