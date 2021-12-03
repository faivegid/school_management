$(document).ready(function () {

    $('#btnCreateCourse').on('click', function () {
        var data = getFormData('form#createCourseForm');
        sendRequestWithData('api/Course/create', 'PUT', data, reloadOnSuccess, error);
    })


    $('div.modal #btnEditCourse').on('click', function () {
        var data = getFormData('form#editCourseForm');
        sendRequestWithData('api/Course/edit', 'PUT', data, reloadOnSuccess, error);
    })


    $('table #btnEditCourse').on('click', function () {
        event.preventDefault();
        const courseId =  $(this).attr("courseId");
        getDataToModalForm(`api/course/${courseId}`, '#editCourseForm', '#editCourseModal');
    })
})