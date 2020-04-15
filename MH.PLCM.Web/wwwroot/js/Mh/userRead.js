
var selectedRow = null;
//onRowSelected
function onRowSelected(e) {
    var row = this.select();
    if (row.length > 0) {
        selectedRow = e.sender.select();
        var row = e.sender.dataItem(selectedRow);
        GetAjaxPostAction(row.Id);

    }

}

function GetAjaxPostAction(param) {
    $.ajax({
        type: 'POST',
        dataType: 'json',
        url: '/IdentityUser/User_Roles',
        data: { userId: param },
        success: function (response) {
            var rolesGrid = $("#userRoles").data("kendoGrid");
            var dataSource = new kendo.data.DataSource({ data: response });
            rolesGrid.setDataSource(dataSource);
            rolesGrid.dataSource.read();
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert(errorThrown);
        }
    });
}
