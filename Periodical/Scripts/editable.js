$(document).ready(function () {
    function editCategory(categoryName, categoryIconName, categoryBackgroundImgName, categoryHomeImgName)
    {
        $("#edit-category-name").val(categoryName);
        $("#edit-category-icon").val(categoryIconName);
        $("#edit-category-background").val(categoryBackgroundImgName);
        $("#edit-category-home").val(categoryHomeImgName);
    }
});