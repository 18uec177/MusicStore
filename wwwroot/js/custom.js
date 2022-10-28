$(document).ready(function () {
    ShowAlbumData();
});

function ShowAlbumData() {
    debugger
    var url = $('#urlAlbumData').val();
    $.ajax({
        url: url,
        type: 'Get',
        dataType: 'json',
        contectType: 'application/json;charset=utf-8;',
        success: function (result, status, xhr) {
            var object = '';
            $.each(result, function (index, item) {
                object += '<tr>';
                object += '<td>' + item.albumId + '</td>';
                object += '<td>' + item.title + '</td>';
                object += '<td>' + item.price + '</td>';
                object += '<td>' + item.genreId + '</td>';
                object += '<td>' + item.artistId + '</td>';
                object += '<td><a href ="#" class= "btn btn-success">Edit<a/> | <a href ="#" class= "btn btn-warning">Delete<a/></td>';
                object += '</tr>';
            });
            $('#table_data').html(object);
        },
        error: function () {
            alert("Data can't be obtained");
        }
    });
}