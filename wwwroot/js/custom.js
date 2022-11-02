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
                object += '<td><a href="#"  onclick="Edit(' + item.albumId + ')" class="btn btn-primary">Edit</a> | <a href ="#" onClick="Delete(' + item.albumId + ')"class= "btn btn-warning">Delete<a/></td>';
                object += '</tr>';
            });
            $('#table_data').html(object);
        },
        error: function () {
            alert("Data can't be obtained");
        }
    });
};


$('#btnAddNewAlbum').click(function() {
    $('#exampleModalCenter').modal('show');
});

function AddAlbum() {debugger
    var objData = {
        AlbumId: $('#AlbumId').val(),
        GenreId : $('#GenreId').val(),
        ArtistId : $('#ArtistId').val(),
        Title : $('#Title').val(),
        Price : $('#Price').val()
    }

    $.ajax({
        url: '/Ajax/AddAlbum',
        type: 'Post',
        data: objData,
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function () {
            alert('Data saved');
        },
        error: function () {
            alert('Data can not be saved');
        }
    })
}




function Delete(id) {
    debugger;
    $.ajax({
        url:'Ajax/Delete?id=' + id,
        success: function () {
            alert('Record Deleted');
            ShowAlbumData();
        },
        error: function () {
            alert("Data can't be deleted");
        }
    })
}

function Edit(id) {
    debugger;
    $.ajax({
        url: '/Ajax/Edit?id=' + id,
        type: 'get',
       
        contentType: 'application/json;charset=utf-8;',
        dataType: 'json',
        success: function (response) {

            $('#exampleModalEdit').modal('show');

            $('#exampleModalEdit #Id').val(response.albumId);
            $("#exampleModalEdit #Title").val(response.title);
           
            $('#exampleModalEdit #Price').val(response.price);
            $('#exampleModalEdit #AlbumArtUrl').val(response.albumArtUrl);
            $('#exampleModalEdit #GenreId').val(response.genreId);
           
            $('#exampleModalEdit #ArtistId  ').val(response.artistId);

        },
        error: function () {
            alert("Data not found");
        }
    })


}
function UpdateAlbum() {
    debugger;
    alert("Working");
    var objData = {
        AlbumId: $('#exampleModalEdit #AlbumId').val(),

        Title: $('#exampleModalEdit #Title').val(),
        Price: $('#exampleModalEdit #Price').val(),
        AlbumArtUrl: $('#exampleModalEdit #AlbumArtUrl').val(),
        GenreId: $('#exampleModalEdit #GenreId').val(),
        ArtistId: $('#exampleModalEdit #ArtistId').val()

    }
    $.ajax({
        url: '/Ajax/Update',
        type: 'POST',
        data: objData,
        contentType: 'application/x-www-form-urlencoded;charset=utf-8;',
        dataType: 'json',
        success: function () {
            alert("Data Saved");
            ShowAlbumData();

        },
        error: function () {
            alert("Data can't be saved");
        }
    })


}


    
