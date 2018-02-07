function CallMethod (url,parameters,succesCallBack){
    $.ajax({
        type: 'POST',
        url: url,
        data: JSON.stringify(parameters),
        contentType: 'application/json;',
        dataType: 'json',
        succes: suceesCallBack,
        error: function (xhr, textStatus, errorThrown)
        {
            console.log('error');
        }
        
    });

}