HtmlToXml
=========

Convert Html to Xml via user defined xml template.  The structure of the xml template will remain unchanged after conversion.  Only the placeholder specified will change.

Placeholders
============

Format
------

The placeholders are regex expression encased in {{}} or [[]].

{{}} returns the outer html.

[[]] returns the inner html.

```
For example, in a HTML with <title>Web Page Title</title>

{{//title}} returns <title>Web Page Title</title> 

[[//title]] returns Web Page Title
```

Reserved Placeholders
---------------------
{{filename}} returns the html file name

{{filepath}} returns the html file path
