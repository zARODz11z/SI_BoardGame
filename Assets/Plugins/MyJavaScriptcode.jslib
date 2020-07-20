mergeInto(LibraryManager.library, {

  SaveFile: function (fileData, fileName){
    download(fileData, fileName, "text/plain" );
  }

});
