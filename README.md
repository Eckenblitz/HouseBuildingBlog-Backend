# HouseBuildingBlog-Backend

This project provides an basic API to document a house building project for owners.

## Concept

### Events

Since such a house building project ist mostly a linear (timely) process. Everything that has happened is considered as "Event". 
Like "Start of digging" has happend on a specific date.
The whole concept of this application is build around "Events". Every Event has a title (brief description), a date (when it happend) and can be attached with images and documents related to this Event.

##### Possible Events
- "Start digging for the base-plate" - 12.04.21 - (attached Images)
- "construction site visit to check progress" - 05.06.21 - (attached Images)
- "Incoming invocice for contract part I" - 24.05.21 - (attached document)
- "Call with construction supervisor about some changes" - 01.07.21

### Documents

During house building you will receive a lot of documents in form of invoices, mails and other things. Such Files can be uploaded and attached to Events,

### Images

Images are important for documentation. They can be uploaded in Galleries and attached to Events.

## Future Features
- Costplan implementation
