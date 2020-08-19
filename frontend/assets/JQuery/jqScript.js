var sourceGlobal;

jQuery(function(){
    //загрузку даннх с сервера на селектор "Выберите источник"

    $.ajax({
        url: "http://localhost:4401/currencyRate/getSource",
        success: function (data) {
            $('#select_source').empty();
            if (data.length == 0){alert('нет источников информации')};
            $.each(data, function() {
                $('#select_source').append(new Option(this.source, this.source));
            })
            AddDatesInSelect(data[0].source);
        },
        errore: function()
        {
            alert('Errore parse data!');
        }
    })

    $("#select_source").change(function (data){
        AddDatesInSelect(this.value);
    })

    $('#select_date').change(function (data){
        AddDataToCurrencySelector(sourceGlobal, this.value)
    })
});


function AddDatesInSelect(source)
{
    sourceGlobal = source;
    $.ajax({
        url: 'http://localhost:4401/currencyRate/getDate',
        type: 'GET',
        data: {source: source},
        success: function(data){
            $('#select_date').empty();
            if (data.length == 0 ){alert('нет данных по датам добавления значений валют')}
            else
                {
                    $.each(data, function() {
                        //substring(0, this.date)  .length - 9
                        var str = this.date.substring(0, this.date.length - 10);
                        $('#select_date').append(new Option(str, str));
                    });
                    var date = data[0].date.substring(0, data[0].date.length - 10);
                    AddDataToCurrencySelector(source, date);
                };
        }
    })
}

function AddDataToCurrencySelector(source, date)
{
    $.ajax({
        url: 'http://localhost:4401/currencyRate/GetListCurrencies',
        type: 'GET',
        data: {source: source, dateToString: date},
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
    var date = document.getElementById('select_date').value;
    var fromCurrency = document.getElementById('from_currency_selector').value;
    var toCurrency = document.getElementById('to_currency_selector').value;
    var rate = document.getElementById('rate').value;
    if (rate < 0){
        alert('Вы ввели отрицательное число');
    }
    else {
        $.ajax({
            url: 'http://localhost:4401/currencyRate/GetCurrencyValue',
            type: 'GET',
            data: {source: source, dateToStr: date, fromCurrency: fromCurrency, toCurrency: toCurrency, value: rate},
            success: function (data) {
                $('.result_container').empty();
                $('.result_container').append('<p class="result_value">' + data.value + '  ' + toCurrency + '</p>')
            }
        });
    }
}