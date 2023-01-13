
$(document).ready(function () {
    $("#SubCategoryItem").attr("disabled", true);
    loadDataTable();
});

$('#CategoryItem').on('change', function () {

    

    let categoryId = $('#CategoryItem').val();
    $('#SubCategoryItem').empty();
    $('#SubCategoryItem').attr("disabled", "disabled");
    $("#SubCategoryItem").attr("disabled", false);
    $('#SubCategoryItem').append('<option selected disabled>Select Sub Category </option>');
    $.ajax({

        url: '/Admin/Articles/LoadSubCategory/' + categoryId,
        type: 'GET',
        dataType:'json',
        success: function (result) {
            var obj = result.data;
           
            $.each(obj, function (i, data) {
               
                $('#SubCategoryItem').append('<option value=' + data.id + '>'+data.name+' </option>');
            })
           
        }

    });

});

function loadDataTable() {
    debugger
    dataTable = $('#tblArticle').DataTable({
        'autoWidth': true,
        "ajax": {
            'url': "/Admin/Articles/GetAll"
            
        },
        'columns': [
            {'data':'title'},
            {'data':'category.name'},
            {
                
                'data': 'subCategoryId',
                'reder': function (data, type, full, meta) {
                    debugger
                    var currentCell = $("#tblArticle").DataTable().cells({ "row": meta.row, "column": meta.col }).nodes(0);
                     $.ajax({
                        url: '/Admin/Articles/GetSubCategoryById/'+data
                     }).done(function (data) {
                         debugger
                         $(currentCell).text(data);
                    });
                }
            },
            { 'data': 'author' },
            {
                'data': 'id',
                'render': function (data) {
                    return '<div class="button-group custom-btn">'
                        + '<button type="button" class="btn btn-sm btn-primary "data-bs-toggle="modal" data-bs-target="#subCategoryModal"><i class="fa-solid fa-eye"></i></button>'
                        + '<div class="dropdown action-button mx-2">'
                        + '<button class="btn btn-success btn-sm dropdown-toggle" type="button" id="dropdownMenuButton1" data-bs-toggle="dropdown" aria-expanded="false"><i class="fa-solid fa-gears"></i> Manage</button>'
                        + '<ul class="dropdown-menu" aria-labelledby="dropdownMenuButton1">'
                        + '<li><a  href="/Admin/Articles/Upsert?Id=' + data + '" class="dropdown-item btn btn-primary"><i class="bi bi-pencil-square"></i> Edit </a></li>'
                        + '<li><a class="dropdown-item btn btn-primary" onClick="Delete(' + data + ')"><i class="bi bi-trash-fill"> </i> Delete</a> </li> </ul> </div> </div>'
                }
            }
            ]

        })
}