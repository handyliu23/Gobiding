/*
Copyright (c) 2003-2011, CKSource - Frederico Knabben. All rights reserved.
For licensing, see LICENSE.html or http://ckeditor.com/license
*/

CKEDITOR.editorConfig = function( config )
{
	// Define changes to default configuration here. For example:
	// config.language = 'fr';
    // config.uiColor = '#AADC6E';
    config.uiColor = '#F7FAFF';
    config.ResizeEnabled = 'false';
    config.language = 'zh-cn'; // 配置语言   
    config.uiColor = '#F7FAFF'; //背景颜色   
    config.width = '780px'; //编辑器显示的宽度   
    config.height = '400px'; // 编辑器显示的高度   
    config.skin = 'kama'; //界面风格 
    config.toolbar = 'MyToolbar'; // 工具栏风格
    config.toolbarCanCollapse = false; // 工具栏是否可以被收缩  
    config.resize_enabled = false; // 取消拖拽改变编辑器的大小 plugins/resize/plugin.js   

    //配置文件上传
    config.filebrowserBrowseUrl = '/ckfinder/ckfinder.html';
    config.filebrowserImageBrowseUrl = '/ckfinder/ckfinder.html?Type=Images';
    config.filebrowserFlashBrowseUrl = '/ckfinder/ckfinder.html?Type=Flash';
    //文件上传路径
    config.filebrowserUploadUrl = '/UserCenter/UploadCKImgHandler.ashx';  
    //图片上传路径
    config.filebrowserImageUploadUrl = '/UserCenter/UploadCKImgHandler.ashx';
    //视频上传路径
    config.filebrowserFlashUploadUrl = '/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash';

    //自Á?定¡§义°?的Ì?工¡è具?栏¤?       
    config.toolbar_MyToolbar =
    [
  ["Source", "-", "Save", "NewPage", "Preview", "-", "Templates"],
  ["Bold", "Italic", "Underline", "Strike", "-", "Subscript", "Superscript"],
  ["NumberedList", "BulletedList", "-"],
//  ["JustifyLeft", "JustifyCenter", "JustifyRight", "JustifyBlock"],
  ["Link", "Copy"],
   "/",
  ["Image", "Flash", "Table", "HorizontalRule", "Smiley", "SpecialChar", "PageBreak", "Iframe"],
  ["Styles", "Format", "Font", "FontSize"],
  ["TextColor", "BGColor"]
  ];
};
