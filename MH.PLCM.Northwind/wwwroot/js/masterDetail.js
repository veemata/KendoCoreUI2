var categoryId;
function onAdditionalData(e) {
    return { CategoryId: categoryId };
}
function selectChange(e) {
    var selectedItems = e.sender.select();
    var dataItem = e.sender.dataItem(selectedItems[0])
    categoryId = dataItem.CategoryId;

    var grid = $('#grdProducts').data('kendoGrid');
    grid.dataSource.read();
}

