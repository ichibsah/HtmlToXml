HtmlToXml
=========

![Screen 1](https://raw.githubusercontent.com/jhuangsoftware/HtmlToXml/master/HtmlToXml/samples/screenshot1.png)

Convert Html to Xml via user defined xml template.  The structure of the xml template will remain unchanged after conversion.  Only the placeholder specified will change.

Placeholders
============

Format
------

The placeholders are xpath expression encased in {{{}}}, {{}}, or {}.

{{{}}} returns the outer html.

{{}} returns the inner html.

{} returns the content in comma separated form

{xpath exression,attribute name} returns attribute value of the matched xpath expression

```
For example, in a HTML with

<div class="title">Web Page Title</div>
<div class="body">Web Page Body</div>

{{{//div[@class="title"]}}} returns <div class="title">Web Page Title</div>

{{//div[@class="title"]}} returns Web Page Title

{//div} returns Web Page Title,Web Page Body

{//div[last()],class} returns body
```

Reserved Placeholders
---------------------
{{filename}} returns the html file name

{{filepath}} returns the html file path
