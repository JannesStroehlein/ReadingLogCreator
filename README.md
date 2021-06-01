# ReadingLogCreator

## Goal
The project tries to simplify the process of creating a reading log for a book. It helps to keep track of the characters and their relations. It also will have a feature to generate a character map.

## Unique Features
1. Per Book FAQ
  - This feature allows you to add per chapter questions that may be answered later in the book
  - Great to keep track of thoughts while reading
2. Character development tracking
  - This software will keep track of how relations between character change over time

## Roadmap
- [x] Open Data Structure with API
- [x] Json Serialization and Deserialization
- [ ] Easy to use UI
- [ ] Graphical character map
  - [ ] Animation on how relations changed over time

## Data Structure
- Reading Log
  - Title
  - Author
  - Release Data
  - Characters
    - Name
    - Is Main Character
    - Extra Information
  - Chapters
    - Title
    - Start Page
    - End Page
    - Summary
    - Notes
    - Character Relations
      - Source
      - Target
      - Relation Type
      - Is Terminated
    - Extra Information
    - FAQ Questions
      - Title
      - Text
      - Answered
      - Answers
        - Text

## Thanks to
Name | Author | Link
------------ | ------------- | -------------
HandyControls | @ghost1372 | [GitHub](https://github.com/ghost1372/HandyControls)
Json.NET | Newtonsoft | [Website](https://www.newtonsoft.com/json)
