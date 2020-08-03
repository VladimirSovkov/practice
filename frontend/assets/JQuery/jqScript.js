var source;
var dateAdded;
var currency;
jQuery(function(){
    //загрузку даннх с сервера на селектор "Выберите источник"
    $.ajax({
        url: "https://localhost:44342/GetSource",
        success: function (data) {
            $('#select_source').empty();
            $.each(data, function() {
                $('#select_source').append(new Option(this, this));
            })
            source = data[0];
            AddDatesInSelect(data[0]);
        }

    })

    $("#select_source").change(function (data){
        AddDatesInSelect(this.value);
    })

    $('#select_date').change(function (data){
        AddDataToCurrencySelector(source, this.value)
    })
});


function AddDatesInSelect(source)
{
    $.ajax({
        url: 'https://localhost:44342/GetAvailableSourceDates',
        type: 'GET',
        data: {source: source},
        success: function(data){
            $('#select_date').empty();
            $.each(data, function() {
                var str = this.substring(0, this.length - 9);
                $('#select_date').append(new Option(str, this));
            });
            dateAdded = data[0];
            AddDataToCurrencySelector(source, data[0]);
        }
    })
}

function AddDataToCurrencySelector(source, date)
{
    $.ajax({
        url: 'https://localhost:44342/GetSourceCurrencySpecificDate',
        type: 'GET',
        data: {source: source, dateToStr: date},
        success: function(data){
            $('#currency_selector').empty();
            $.each(data, function() {
                $('#currency_selector').append(new Option(this, this));
            });
            currency = source[0];
        }
    })
}

function GetValueRate()
{
    var value1 = document.getElementById('select_source').value;
    var value2 = document.getElementById('select_date').value;
    var value3 = document.getElementById('currency_selector').value;
    var value4 = document.getElementById('rate').value;
    $.ajax({
        url: 'https://localhost:44342/GetСurrencyValue',
        type: 'GET',
        data: {source: value1, dateToStr: value2, currency: value3, valueToStr: value4},
        success: function (data)
        {
            $('.result_container').append('<p>' + data + '</p>');
        }
    })

}