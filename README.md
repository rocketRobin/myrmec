## Version 1.1 released!

1. Support discontinuous binary, such as `0x11,0x22,??,??,0x33,0x66`
2. Support offset, such as `0x11,0x22,0x33` but has offset 10
3. Obsolete `FileTypes.CommonFileTypes ` and instead with `FileTypes.Common`
By the way: now fully support jpeg.


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
    // FileTypes.Common contains file types that we usually see.
    sniffer.Populate(FileTypes.Common);
	
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

## Api ducument ##

[github pages](https://rocketrobin.github.io/myrmec-website/api/index.html)

## Matedate source ##

the metadata information from wiki pedia [List of file signatures](https://en.wikipedia.org/wiki/List_of_file_signatures).

