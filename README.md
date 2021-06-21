# HeyCuratorCapstone
Capstone Project for the Proof of Concept/Working model of the "Hey Curator" museum curation system.


### Test Server (Not for External Review, Placeholder as it is still accessible and seeing daily pushes
Under Development. May not function correctly.  
[Hey Curator! Pre-Demo](https://timherron.dev/heycurator)



# Todo List to hit Demo/Prototype Goal:

## Museum Structure / Admin
### Creational
These include create/add new "Models" to the Museum Structure.  
Completed means Controller Method and required views within Admin are complete.
- [x] Create Curator Role
- [x] Create Employee (Currently accessible through the use of the AdminSecrets Code.)
- [x] Create Exhibit Space
- [x] Create Exhibit
- [x] Create Item (Type)
- [x] Create Item Instance
- [x] Create Inventory Model (Required Initial Constructed at same time as Item Instance)
- [x] Create Storage
### Relational / Assignment
These include assigning "Models" to their related Association.
Example: Assign an Employee to a Curator Role, Add Exhibits to an Exhibit Space  
(Complete, Includes both Add/Remove, perferable one checklist view)
- [x] Assign Employee to Curator Role 
- [x] Assign Exhibit Space to Curator Role
- [x] Assign / Add Exhibits to Exhibit Space
- [ ] Assign Item Instances to Exhibits
- [ ] Assign Item Instances to Storages
## Informational
### Detail Pages
Convert Old Views
- [ ] Details about an Employee
- [ ] Details about a Curator Role
- [ ] Details about an Exhibit Space
- [ ] Details about an Exhibit
- [ ] Details about an Item (Type)
- [ ] Details about an Item Instance (Ref all matching Items/Exhibits/Storages)
- [ ] Details about a storage.
- [ ] Details about a record.
### Detail Pages Extensions / Full Connection Reference (May be pushed to next stage)
- [ ] Employee 
- [ ] Curator Role
- [ ] Exhibit Space
- [ ] Exhibit
- [ ] Item
- [ ] Item Instance
- [ ] Storage
## Inventory Control
- [ ] Add Record to an Item Instance (Migrate old version prev. working model)
- [ ] Modify record / add Curator Verification Check / Remove from Expired if Order has Occured (Migrate from prev. working state)
- [x] Background item expiration service (Still functional for old model, requires changes as models change in revision.) 
- [ ] Place Order Notification for an Item Instance / Inventory Control Model
- [ ] Update Expired List Views
## Database Design
- [x] Employee Model
- [x] Employee Role (Employee/Curator Role join)
- [x] Curator Role Model
- [x] Curator Spaces (Curator Role / Exhibit Space join)
- [x] Exhibit Space Model
- [x] Exhibit Model
- [x] Item (Type)
- [x] Item Instance Model
- [x] Inventory Control Model
- [x] Record Model
- [x] Storage Item Instance (Item Instance / Storage join)
- [x] Storage Model
- [ ] Order Model
- [x] Anonymous Question Model
- [ ] Generic Log Model
### Goals via Db Design
- [x] Enforce naming convention / standard name for all Model / Entities. (See Future Update Nicknames)
- [ ] Create an up and downstream retrieval of information. (Future iterations may have special models for non-standard relations. Example, Curator in charge of an exhibit not in their Exhibit Space.)
## Anonymous Question Board (Look at renaming this Feature)
- [x] Anonymouse Question Board Read and Comment. 
- [ ] Search Anonymous Question

## Message System
- [x] Toast Pop up for Admin features
- [x] Delayed Toast to ensure User created are seen by user
- [x] Test Chat Messages (still functional) Planned Depreciation / Removal.
- [ ] Fix Graphical issues in Chat Message Bubble

## Services
- [ ] Continue to depreciate in favor of Repository Design Pattern.

## Misc
- [x] Repository Design Pattern
- [ ] New Logging System
- [ ] Refactor old service pattern
- [ ] Check Color Codes
- [ ] Migrate Auto QR code generation
- [ ] Generic ChartJS view of Inventory Control history.
(See ERD / Design pdfs)
![Model Simple Layout Color Code](https://raw.githubusercontent.com/tmherron09/HeyCuratorCapstone/MVC_Switch/Model_SimpleLayout_ColorCode.png)
![ER Split Color Code](https://raw.githubusercontent.com/tmherron09/HeyCuratorCapstone/MVC_Switch/ER_Split_Color_Code.png)


# Planned Features for Future Iterations
## Extended detail models
- [ ] Add Cleaning Information model that can be referenced at any Model level.
- [ ] Add Education Information Model
- [ ] Add Information regarding model during Special Events.
- [ ] Add Special Hours (special opening times) Model
- [ ] Add Nicknames (for example, Exhibit has a non-standard name, to make it easier for staff to search an Exhibit everyone knows by a different title.)
- [ ] Add History Model
## Archive to store models / entities as they are replaced but to maintain for reference.
- [ ] Extend Logging system into archival information for past exhibits, former items used in exhibits or educations plans.
