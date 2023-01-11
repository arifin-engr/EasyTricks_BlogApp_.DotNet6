
let dataTable;
$(document).ready(function () {
    debugger
    loadDataTable();
});

function loadDataTable() {
    debugger
    dataTable = $('#tblCategory').DataTable({
        "autoWidth": true,
        "ajax": {
            "url":"/Admin/Categories/GetAll"
        },
        "columns": [
            { "data": "title" },
            {
                "data": "id",
                "render": function (data) {
                    debugger
                    return '<div class="button-group"'
                    + '<div class="dropdown action-button mx-2">'
                        + '<button class="btn btn-success btn-sm dropdown-toggle" type="button" id="dropdownMenuButton1" data-bs-toggle="dropdown" aria-expanded="false"><i class="fa-solid fa-gears"></i> Manage</button>'
                        + '<ul class="dropdown-menu" aria-labelledby="dropdownMenuButton1">'
                        + '<li><a  href="/Admin/Categories/Upsert?Id=' + data + '" class="dropdown-item btn btn-primary"><i class="bi bi-pencil-square"></i> Edit </a></li>'
                        + '<li><a class="dropdown-item btn btn-primary" onClick="Delete(' + data + ')"><i class="bi bi-trash-fill"> </i> Delete</a> </li> </ul> </div> </div>'
                }
            }
            ]

    });
}