$(function () {
    $("#add").click(function (e) {
        e.preventDefault();
        
        var i = $(".items").length;

        var y = `
        <div class="card mb-4">
            <div class="card-body">
                <h3 class="h6">Resource</h3>
                   <div class="field-input-data">
                        <label>Name of resource</label>
                        <input  style="margin-bottom: 5px; border-color: #DDDDDD; border-radius: 5px" type="text" class="items" name="Resources[` + i + `].Name" />
                    </div>
                    <div>
                        <label>URL</label>
                        <input  style="margin-bottom: 5px; border-color: #DDDDDD; border-radius: 5px" type="text" class="items" name="Resources[` + i + `].UrlResource" />
                    </div>
            </div>
        </div>`;

        var n = '<input type="text" class="items" name="ListItems[' + i + '].Name" />';
        var k = '<input type="text" class="items" name="ListItems[' + i + '].UrlResource" />';
        $("#item-list").append(y);
    });

});