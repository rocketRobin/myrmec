## News

next version almost done,but need some test.
If you want a .net framework version or want to reconize jpg file, please download the source code,it already support this.
I've been busy recently ... When I have some time， I will make tests and release next version, thanks.


## What is Myrmec ##
Myrmec is a library that used to identifie real file format type by detecting the file binary head with out file extention like `xxxxx.png`.

## How to use ##

That was very easy.

### Install from nuget ###

	Install-Package Myrmec
### Or DotNet cli ###
	
	dotnet add package Myrmec

### Write code ###

    // create a sniffer instance.
    Sniffer sniffer = new Sniffer();

	// populate with mata data.
    sniffer.Populate(FileTypes.CommonFileTypes);
	
	// get file head byte, may be 20 bytes enough.
    byte[] fileHead = ReadFileHead();

	// start match.
    List<string> results = sniffer.Match(fileHead);

Many times the results has more than one value, because some file format has multiple extentions, such as jpeg,jpg. or some extentions that point to same file format like apk,zip,pptx they are all zip archive.

### Find one result vs multiple result ###

	// this will match one result that sniffer first matched.
	// default is false
    List<string> results = sniffer.Match(fileHead,false);

	// this will match all result that sniffer matched.
    List<string> results = sniffer.Match(fileHead,true);

### Add your own file format head into metadata ###

May be you make some file format,or the `FileTypes.CommonFileTypes` not contains the file format that you need, then you can add it in :

    var data = new byte[]
    {
        0x11,
        0x22,
        0x33
    };
    sniffer.Add(data, new[] { "what", "file", "type" });

The variable data is file hex head that you want to add, ` new[] { "what", "file", "type" }` mean that this file type has three extention that named what,file,type. When you match this head will return three result at least*(may be some other file type has same hex head or it's head contains above head(but only on match multiple))*.

### Get the MIME type ###

Suprise! this library also offer the function is get Mime type:

	List<string> result = sniffer.Match(head);
	string mimeType = MimeTypes.GetMimeType(result.First());

But, some thing that you need to know is this function relay on file extention name, you can write like this:

	string mimeType = MimeTypes.GetMimeType("png");

The result is 

	image/png



## Matedate source ##

the metadata information from wiki pedia [List of file signatures](https://en.wikipedia.org/wiki/List_of_file_signatures).


## Not support ##

The file type matedate only suport that file hex head has no offset and byte value continuous, for example, the following examples do not support:

Jpg file

	jpg file head not support: FF D8 FF E0 ?? ?? 4A 46 49 46 00 01

this format middle part allows an arbitrary value, but another jpg format is supported:

Jpg file

	jpg file head supported: FF D8 FF DB 

PDB file

	PDB file head not support: 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00

this format has offset 11,so not support.

## Road Map

1. Next major vertion I will add the support of file format that contains offset or contains arbitrary value.

