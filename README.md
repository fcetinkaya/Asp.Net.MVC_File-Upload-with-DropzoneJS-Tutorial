# Asp.net Mvc - File Upload with DropzoneJS
> With this project, you can add / delete pictures.

## Table of contents
* [General info](#general-info)
* [Screenshots](#screenshots)
* [Technologies](#technologies)
* [Code Examples](#code-examples)

## General info
You can make modern and effective projects by using jquery and dropzone libraries.

## Screenshots
![Example screenshot](./product_list.jpg)
![Example screenshot](./product_AddImage.jpg)

## Technologies
* .NET Framework 4.6.1+
* .NET Standard 3.1, providing .NET Core support
* Install latest version of Visual Studio : https://www.visualstudio.com/downloads/
* Nuget DropzoneJS : https://www.nuget.org/packages/dropzone/
* Nuget Microsoft jQuery Unobtrusive Ajax : https://www.nuget.org/packages/Microsoft.jQuery.Unobtrusive.Ajax/

## Setup
Describe how to install / setup your local environement / add link to demo version.

## Code Examples
Show examples of usage:
```
Dropzone.autoDiscover = false;
        $(function () {
            var dz = null;
            $("#mydropzone").dropzone({
                autoProcessQueue: false,
                paramName: "productpictures",
                maxFilesize: 1, //mb
                maxThumbnailFilesize: 1, //mb
                maxFiles: 5,
                parallelUploads: 5,
                acceptedFiles: ".jpeg,.png,.jpg",
                uploadMultiple: true,
                addRemoveLinks: true,
                //resizeWidth:128,
                init: function () {
                    dz = this;
                    $("#uploadbutton").click(function () {
                        dz.processQueue();
                        $(this).attr("disabled", "disabled");
                    });
                },
                success: function (file) {
                    var preview = $(file.previewElement);
                    preview.addClass("dz-success text-success");
                    setTimeout(function () {
                        dz.removeFile(file);
                        $("#refreshbutton").click();
                    }, 2000);
                },
                queuecomplete: function () {
                    $("#refreshbutton").click();
                    $("#uploadbutton").removeAttr("disabled");
                },
                dictDefaultMessage: "You can drag and drop your images here.",
                dictRemoveFile: "File Remove"
            });
            $("#refreshbutton").prepend('<i id="loading" class="fa fa-refresh fa-spin" style="display:none;"></i>&nbsp;')
            refreshProductPicture();
        });
        function refreshProductPicture() {
            $("#refreshbutton").click();
        }
```

