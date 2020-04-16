$(function () {
    $("#saveGridState").click(function (e) {
        var gridSettings = kendo.stringify($("#grdProducts").data("kendoGrid").getOptions());
        $.ajax({
            type: "POST",
            cache: false,
            url: "/Northwind/Grid/SaveProductGridSettings",
            data: { optionsData: gridSettings }
        });
        console.log('Grid Status Saved');
        e.preventDefault();
    });

    $("#loadGridState").click(function (e) {
        $.ajax({
            type: "POST", cache: false, url: "/Northwind/Grid/GetProductGridSettings", data: {},
            success: function (options) {
                if (options) {
                    $("#grdProducts").data("kendoGrid").setOptions(JSON.parse(options));
                }
            },
        });
        console.log('Grid Status Restored')
        e.preventDefault();
    });


    $("#saveFilter").click(function (e) {
        e.preventDefault();
        //  localStorage["kendo-filter-options"] = kendo.stringify($("#filter").getKendoFilter().getOptions());
        var filterSettings = kendo.stringify($("#filter").getKendoFilter().getOptions());
        $.ajax({
            type: "POST",
            cache: false,
            url: "~/Northwind/Grid/SaveProductGridSettings",
            data: { optionsData: filterSettings }
        });
        console.log('Grid Filter  Saved');
    });

    $("#loadFilter").click(function (e) {
        $.ajax({
            type: "POST", cache: false, url: "/Northwind/Grid/GetProductGridFilterSettings", data: {},
            success: function (options) {
                if (options) {
                    $("#filter").getKendoFilter().setOptions(JSON.parse(options));
                    $("#filter").getKendoFilter().applyFilter();
                }
            },
        });
        console.log('Grid Filter  Loaded');
        e.preventDefault();
    });

});