$(document).ready(function () {


    loadDataTable();
});


function loadDataTable() {

    dataTable = $('#tblSubCategory').DataTable({
        "autoWidth": true,
        "ajax": {
            "url": "/Admin/SubCategories/GetAll"
        },
        "columns": [
            { "data": "name" },
            { "data": "category.name" },
            {
                "data": "id",
                "render": function (data) {

                    return '<div class="button-group custom-btn">'
                        +'<button type="button" class="btn btn-sm btn-primary "data-bs-toggle="modal" data-bs-target="#subCategoryModal"><i class="fa-solid fa-eye"></i></button>'
                        + '<div class="dropdown action-button mx-2">'
                        + '<button class="btn btn-success btn-sm dropdown-toggle" type="button" id="dropdownMenuButton1" data-bs-toggle="dropdown" aria-expanded="false"><i class="fa-solid fa-gears"></i> Manage</button>'
                        + '<ul class="dropdown-menu" aria-labelledby="dropdownMenuButton1">'
                        + '<li><a  href="/Admin/SubCategories/Upsert?Id=' + data + '" class="dropdown-item btn btn-primary"><i class="bi bi-pencil-square"></i> Edit </a></li>'
                        + '<li><a class="dropdown-item btn btn-primary" onClick="Delete(' + data + ')"><i class="bi bi-trash-fill"> </i> Delete</a> </li> </ul> </div> </div>'
                }
            }
        ]

    });
}

function Delete(id) {


    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: "/Admin/SubCategories/Delete/" + id,
                type: "DELETE",
                success: function (data) {

                    if (data.success) {
                        dataTable.ajax.reload();
                        toastr.success(data.message)
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            })
        }
    })
}