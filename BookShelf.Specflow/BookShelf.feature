﻿Feature: BookShelf
	In order manage my virtual bookshelf
	As an reader of books
	I want to add and remove books to my shelf

Background: 
	Given I am using the virtual bookshelf

Scenario: Retrieve a list of books
	Given I have searched for a book about 'dinosaurs'
	Then I retrieve a page of 10 results

Scenario: Finding a particular book
	Given I have searched for the book 'harry potter and the chamber of secrets'
	Then 'harry potter and the chamber of secrets' is on the first page of results

