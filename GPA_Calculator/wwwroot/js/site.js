/**
    * @param {string} url - The api url to request to
    * @param {string} type - The type of request either 'PUT','POST' or  'PATCH'
    * @param {JSON} data - The data needed for the request 
    * @param {Function} successCallBack - The callback functon to be executed when the request is successfull
    * @param {Function} errorCallback - The error function to be executed when an error occur during request.
    */
function sendRequestWithData(url, type, data, successCallBack, errorCallback) {
    $.ajax({
        type: type,
        url: url,
        data: JSON.stringify(data),
        contentType: "application/json",
        success: successCallBack,
        error: errorCallback
    })
}


function reloadOnSuccess(response) {
    console.log("success");
    location.reload();
}


function error(response) {
    console.log("error occured");
    console.log(response);
}


/**
 * @param {string} formSelector - The selector to select the form which is to be posted
 */
function getFormData(formSelector) {
    const data = {};
    $.each($(formSelector).serializeArray(), function () {
        data[this.name.toString()] = this.value;
    })
    return data;
}


/**
 * @param {string} formSelector -The selector to select the form which data is to be passed to
 * @param {JSON} data - The data in key-value pari Note the key must be names in the form
 */
function passDataToForm(formSelector, data) {
    const $form = $(formSelector);
    $.each(data, (prop, propValue) => {
        $form.find("input[name='" + prop + "'").val(propValue);
    });
}


/**
     * 
     * @param {string} url - The url to make the get request
     * @param {string} formSelector - The selector for the form to pass data from get request
     * @param {string} modalId - The modal id to sho it.
     */
function getDataToModalForm(url, formSelector, modalId) {
    $.ajax({
        type: 'GET',
        url: url,
        dataType: 'JSON',
        success: (response) => {
            console.log('success');
            console.log(response);
            passDataToForm(formSelector, response);
            $(modalId).modal('show');
        },
        error: (errorResponse) => {
            console.log("error occured");
            console.log(errorResponse);
            alert("An error occured refresh page and try again!");
        }
    })
}