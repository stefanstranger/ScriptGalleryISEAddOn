add-type -path "C:\Users\stefstr\Documents\GitHub\PowerShell\ScriptGalleryISEAddOn\ScriptGalleryISEAddOn\ScriptGalleryISEAddOn\bin\Debug\ScriptGalleryISEAddOn.dll"

$psISE.CurrentPowerShellTab.VerticalAddOnTools.Add('ScriptGalleryUpload', [ScriptGalleryISEAddOn.ScriptGallery], $true)

