
jQuery(function(){
    //создание input с значением 'max' = today
    $(function() {
        var today = new Date();
        var dd = today.getDate();
        var mm = today.getMonth()+1; //January is 0!
        var yyyy = today.getFullYear();
        if(dd<10){
            dd='0'+dd
        }
        if(mm<10){
            mm='0'+mm
        }

        today = yyyy+'-'+mm+'-'+dd;
        document.getElementById("input_date").setAttribute("max", today);
    });

    //загрузку даннх с сервера на селектор "Выберите источник"
    $.ajax({
        url: "http://localhost:4401/currencyRate/getSource",
        success: function (data) {
            $('#select_source').empty();
            if (data.length == 0){alert('нет источников информации')};
            $.each(data, function() {
                $('#select_source').append(new Option(this.source, this.source));
            })
            AddDataToCurrencySelector(data[0].source);
        },
        error: function()
        {
            alert('не могу подключиться к серверу ');
        }
    })

    $("#select_source").change(function (data){
        AddDataToCurrencySelector(this.value)
    });

    $('#input_date').click(function(){
        $("#input_date").css({"border-color":($('.source_selection').css("border-color")), "border-width":($('.source_selection').css("border-width"))});
        $('.error_field').text("");
    });

    $('#rate').click(function(){
        $("#rate").css({"border-color":($('.source_selection').css("border-color")), "border-width":($('.source_selection').css("border-width"))});
        $('.error_field').text("");
    });
});

function AddDataToCurrencySelector(source)
{
    $.ajax({
        url: 'http://localhost:4401/currencyRate/GetListCurrencies',
        type: 'GET',
        data: {source: source},
        success: function(data){
            $('#to_currency_selector').empty();
            $('#from_currency_selector').empty();
            if(data.length == 0){alert('нет данных в наличии валют')}
            $.each(data, function() {
                $('#to_currency_selector').append(new Option(this.currency, this.currency));
                $('#from_currency_selector').append(new Option(this.currency, this.currency));
            });
        }
    })
}

function GetValueRate()
{
    var source = document.getElementById('select_source').value;
    var date = document.getElementById('input_date').value;
    var fromCurrency = document.getElementById('from_currency_selector').value;
    var toCurrency = document.getElementById('to_currency_selector').value;
    var rate = document.getElementById('rate').value;
    if(date == "")
    {
        $('.error_field').text('Введите дату');
        $("#input_date").css({"border-color":"red", "border-width":"3px"})
        return;
    }
    if (rate < 0){
        $('.error_field').text('Вы ввели отрицательное число');
        $("#rate").css({"border-color":"red", "border-width":"3px"})
        return
    }
    else {
        $.ajax({
            url: 'http://localhost:4401/currencyRate/GetValue',
            type: 'POST',
            data: JSON.stringify({source: source, date: date, fromCurrency: fromCurrency, toCurrency: toCurrency, value: rate}),
            contentType: 'application/json; charset=utf-8',
            cache: false,
            success: function (data) {
                $('.result_container').empty();
                $('.result_container').append('<p class="result_value">' + data.value + '  ' + toCurrency + '</p>')
            },
            error: function (jqXHR, exception){
                var responseText = jqXHR.responseText;
                if (responseText === "\"invalid date range\"")
                {
                    alert('Введена некорректная дата');
                } else if (responseText === "\"no data for one of the currencies\"") {
                    alert('Нет курса кнвертации');
                };
            }
        });
    }
}