$(function () {

    $('#EstadoDivID').hide();
    $('#SubmitID').hide();

    $('#CHPais').change(function () {
        //var URL = $('#FormPaisID').data('stateListAction');
        var URL = '/Pais/SearchEstado';
        $.getJSON(URL + '/' + $('#CHPais').val(), function (data) {
            var items = '<option>Selecione um Estado</option>';
            $.each(data, function (i, state) {
                items += "<option value='" + state.Value + "'>" + state.Text + "</option>";
                // state.Value cannot contain ' character. We are OK because state.Value = cnt++;
            });
            $('#EstadosID').html(items);
            $('#EstadoDivID').show();

        });
    });

    $('#EstadosID').change(function () {
        $('#SubmitID').show();
    });
});