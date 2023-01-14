$(document).ready(function () {

    loadDataTable();
});
function loadDataTable() {
    debugger
    dataTable = $('#tblRoleList').DataTable({
        'autoWidth': true,
        "ajax": {
            'url': "/Admin/AccessManagers/GetAllRole"

        },
        'columns': [
            { 'data': 'name' },
            {
                'data': 'id',
                'render': function (data) {
                    return '<div class="button-group ">'
                        + '<div class="dropdown action-button mx-2">'
                        + '<button class="btn btn-success btn-sm dropdown-toggle" type="button" id="dropdownMenuButton1" data-bs-toggle="dropdown" aria-expanded="false"><i class="fa-solid fa-gears"></i> Manage</button>'
                        + '<ul class="dropdown-menu" aria-labelledby="dropdownMenuButton1">'
                        + '<li><a  href="/Admin/AccessManagers/UpsertRole?Id=' + data + '" class="dropdown-item btn btn-primary"><i class="bi bi-pencil-square"></i> Edit </a></li>'
                        + '<li><a class="dropdown-item btn btn-primary" onClick="Delete(' + data + ')"><i class="bi bi-trash-fill"> </i> Delete</a> </li> </ul> </div> </div>'
                }
            }
        ]

    })
}

