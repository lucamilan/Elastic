Elastic is a framework that helps to simplify the "wiring" phase of our applications. Elastic promote Composition Root pattern by MEF.

Usage:

//in our app entry point, global.asax for example

var container = new Container();
Bootstrap.This(() => container);