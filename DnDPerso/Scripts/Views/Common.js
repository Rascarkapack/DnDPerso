var common =
{
    customRequest: function(requestType, serviceName, methodName, data, callBackFunction) {
        var targetUrl = "/" + serviceName + "/" + methodName;

        $.ajax(
        {
            type: requestType,
            url: targetUrl,
            dataType: "json",
            contentType: "application/json;charset=utf-8",
            data: data,
            cache: false,
            beforeSend: function() {
                if (typeof loadingPanel != 'undefined' && loadingPanel !== null) {
                    loadingPanel.Show();
                }
            },
            success: function(result) {
                if (callBackFunction !== null) {
                    callBackFunction(result);
                }

                if (result.Message !== undefined && result.Message.length > 0) {
                    common.checkResult(result);
                }

                if (typeof loadingPanel != 'undefined' && loadingPanel !== null) {
                    loadingPanel.Hide();
                }
            },
            statusCode:
            {
                504: function() { alert("Wrong password or login"); }
            },
            error: function(xhr, textStatus, thrownError) {
                common.checkResult(xhr.responseText);
            }
        });
    },

    addAntiForgeryToken: function(data) {
        data.__RequestVerificationToken = $("[name='__RequestVerificationToken']").val();
        return data;
    },

    CurrencyFormatted: function (amount) {
        var i = parseFloat(amount);
        if (isNaN(i)) {
            i = 0.00;
        }
        var minus = '';
        if (i < 0) {
            minus = '-';
        }
        i = Math.abs(i);
        i = parseInt((i + .005) * 100);
        i = i / 100;
        s = new String(i);
        if (s.indexOf('.') < 0) {
            s += '.00';
        }
        if (s.indexOf('.') == (s.length - 2)) {
            s += '0';
        }
        s = minus + s;
        return s;
    },

    // Important : Do not use JSON.stringify for the data parameter
    customRequestSecured: function(requestType, serviceName, methodName, data, validationToken, callBackFunction) {
        var targetUrl = "/" + serviceName + "/" + methodName;

        $.ajax(
        {
            type: requestType,
            headers: { "__RequestVerificationToken": validationToken },
            url: targetUrl,
            dataType: "json",
            data: common.addAntiForgeryToken(data),
            success: function(result) {
                if (callBackFunction !== null) {
                    callBackFunction(result);
                }

                if (result.Message !== undefined && result.Message.length > 0) {
                    common.checkResult(result);
                }

                if (typeof loadingPanel != 'undefined' && loadingPanel !== null) {
                    loadingPanel.Hide();
                }
            },
            statusCode:
            {
                504: function() { alert("Wrong password or login"); }
            },
            error: function(xhr, textStatus, thrownError) {
                common.checkResult(xhr.responseText);
            }
        });
    },

    checkResult: function(result) {
        var duration = 5000;
        if (result.duration !== 'undefined' && result.duration !== null) {
            duration = result.duration;
        }

        //toastr.options =
        //{
        //    positionClass: 'toast-bottom-right',
        //    timeOut: duration,
        //    extendedTimeOut: "1000",
        //    showEasing: "swing",
        //    hideEasing: "linear",
        //    showMethod: "fadeIn",
        //    hideMethod: "fadeOut"
        //};

        //if (result.Level !== 'undefined' && result.Level !== null) {
        //    switch (result.Level) {
        //    case "success":
        //        toastr.success(result.Message);
        //        break;
        //    case "info":
        //        toastr.info(result.Message);
        //        break;
        //    case "warning":
        //        toastr.warning(result.Message);
        //        break;
        //    case "error":
        //        toastr.error(result.Message);
        //        break;
        //    default:
        //        break;
        //    }
        //} else toastr.warning(result.Message);
    }
}
