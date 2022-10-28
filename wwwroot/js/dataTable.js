$(document).ready(function () {
    $('#myTable').DataTable({

    });
});

$('#myModal').on('shown.bs.modal', function () {
    $('#myInput').trigger('focus')
})


