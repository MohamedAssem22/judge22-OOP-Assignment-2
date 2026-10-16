### 1. AppointmentDesk

#### Distinct Responsibilities Identified:
1. **Operating Hours Rules:** Defining business days/hours policies (e.g., weekend closures and clinic operating slots).
2. **Booking & Slot Management:** Tracking booked appointments and searching for available slots.
3. **Calendar Exporting:** Formatting appointment details into ICS calendar files.
4. **Messaging / Reminders:** Formatting SMS notification copy.

#### Why Having Them Together Is a Problem:
Mixing operational schedule rules, booking state tracking, ICS calendar formatting, and SMS template generation in one class creates multiple reasons to change:
- Changes to SMS notification wording or calendar format standard force edits to business rules.
- Updating operating hours policy risks corrupting the internal booking state tracking logic.
- It couples formatting and messaging dependencies directly to core domain scheduling logic.



### 2. CheckoutBasket

#### Distinct Responsibilities Identified:
1. **Cart Line Items & Subtotal Calculation:** Managing added products and calculating the raw subtotal.
2. **Coupon / Discount Parsing & Logic:** Interpreting marketing coupon strings and calculating discount amounts.
3. **Gift Packaging & Messaging Policy:** Handling gift wrap flags and generating customer-facing gift card message text.
4. **Payment Gateway Authorization:** Simulating payment gateway interactions and generating authorization tokens.

#### Why Having Them Together Is a Problem:
Coupling item math, coupon text string parsing, gift card marketing copy, and payment gateway simulation into a single class causes tight coupling and multiple reasons to change:
- Marketing changes to coupon rules or gift message wording force risky modifications to cart pricing math.
- Changes to payment authorization algorithms or security hashes contaminate core shopping cart logic.
- It completely violates single responsibility by mixing domain rules, string formatting, and external service stubs.



### 3. CourseEnrollmentDesk

#### Distinct Responsibilities Identified:
1. **Enrollment & Waitlist State Management:** Handling student seat capacity, waitlist ordering, registration rules, and promotions.
2. **Welcome Packet Content Formatting:** Generating student onboarding Markdown copy and status messaging.
3. **Tuition Invoice Formatting:** Calculating tax/VAT and generating financial CSV/text invoice strings.

#### Why Having Them Together Is a Problem:
Mixing stateful enrollment logic, content design (Markdown copy), and financial tax/invoice rules in one class creates split reasons to change:
- Changing marketing or onboarding materials forces edits inside seat/waitlist math code.
- Updates to tax rates or invoicing formats risk breaking core registration capacity logic.
- Text formatting dependencies contaminate pure domain business rules.




### 5. KitchenTicket

#### Distinct Responsibilities Identified:
1. **Allergen Detection:** Scanning ingredient lists against regulatory allergen dictionaries.
2. **Cook Time & Routing Heuristics:** Calculating estimated preparation times and lane dispatch routing based on station availability and delay protocols.
3. **Thermal Printer Formatting:** Rendering output text layout formatted for physical thermal printer hardware.

#### Why Having Them Together Is a Problem:
Coupling hardware ticket rendering, operational prep-time algorithms, and allergen policy rules into one class creates disjointed reasons to change:
- Changing printer paper width or receipt layout breaks/requires editing core kitchen estimation formulas.
- Regulatory changes to allergen tracking force modifications on ticket printing and routing logic.
- Physical infrastructure formatting concerns contaminate pure culinary business logic.





### 6. LoanDesk

#### Distinct Responsibilities Identified:
1. **Underwriting & Risk Calculation:** Computing applicant risk scores based on credit history, employment duration, and loan amounts, alongside eligibility determination rules.
2. **Compliance Documentation Policy:** Assembling required document checklists according to regulatory and financial thresholds.
3. **Legal Correspondence & Analytics Export:** Generating legal/customer-facing decision letters and formatting underwriter analytics CSV rows.

#### Why Having Them Together Is a Problem:
Mixing financial risk algorithms, compliance document requirements, and customer communications/CSV schemas creates conflicting reasons to change:
- Changes to risk committee formulas or credit thresholds risk breaking legal letter templates and export schemas.
- Updates to regulatory document requirements or audit reporting layouts force risky modifications to core underwriting math.
- Text formatting and communications copy tightly couple with core financial domain rules.



### 7. SubscriptionBilling

#### Distinct Responsibilities Identified:
1. **Proration & Calendar Math:** Computing proportional subscription prices based on activation and billing period dates.
2. **Invoice Numbering Service:** Minting unique, sequential invoice identifiers and fiscal prefixes.
3. **Billing Correspondence & Ledger Formatting:** Generating dunning/collection email bodies and exporting accounting ledger journal lines.

#### Why Having Them Together Is a Problem:
Mixing financial proration math, sequential invoice numbering side-effects, and collections text formatting/ledger exports creates multiple reasons to change:
- Changes to fiscal numbering formats or prefixes risk breaking financial proration or ledger export formats.
- Updates to collection email phrasing or tone contaminate core calculation and accounting rules.
- Side-effects within email generation (like minting invoice numbers on the fly) tightly couple distinct operations, making unit testing brittle.




### 8. SupportTicket

#### Distinct Responsibilities Identified:
1. **Priority Keyword Heuristics:** Scanning free-text subject and body content for critical keywords to assign priority bands.
2. **SLA Calculation & Breach Detection:** Computing deadline timestamps based on operational SLA tiers and verifying compliance against current time.
3. **Correspondence & Escalation Formatting:** Drafting customer-facing response emails and formatting internal escalation blurbs.

#### Why Having Them Together Is a Problem:
Mixing NLP text heuristics, operational SLA math, and CX communication templates creates disjointed reasons to change:
- Adjusting keyword priorities forces changes inside time-sensitive SLA calculation logic.
- Updates to customer support email templates or escalation schemas risk introducing errors into deadline math.
- Business rules for text analysis pollute time-based domain constraints.




### 9. WardBoard

#### Distinct Responsibilities Identified:
1. **Clinical Acuity Scoring:** Evaluating vital signs (heart rate and SpO2) to compute clinical acuity risk scores.
2. **Pager Alert Protocols:** Managing emergency notification logs and paging queue dispatches based on acuity thresholds.
3. **Clinical Documentation & Census Formatting:** Drafting nurse handoff notes and exporting ward census CSV reports.

#### Why Having Them Together Is a Problem:
Mixing clinical risk evaluation math, hardware paging notifications, and nurse handoff/CSV formatting creates conflicting reasons to change:
- Changes to clinical triage guidelines force modifications to code handling pager notifications and report generation.
- Updates to handoff documentation templates or CSV schema layouts risk introducing bugs into time-sensitive patient acuity logic.
- Operational pager dispatch mechanics pollute pure clinical scoring logic.




### 10. WarehousePickList

#### Distinct Responsibilities Identified:
1. **Inventory Stock Allocation Policy:** Calculating fulfilled versus shorted quantities based on requested needs and on-hand inventory levels.
2. **Warehouse Path & Route Optimization:** Determining optimal walking sequences through aisles and bins according to facility spatial layout heuristics.
3. **Handheld UX Formatting & WMS XML Integration:** Formatting human-readable picker instructions/warnings for handheld terminals and outputting structured XML batch payloads for WMS integration.

#### Why Having Them Together Is a Problem:
Coupling stock allocation calculations, aisle/bin routing logic, handheld UI script generation, and third-party WMS XML serialization introduces multiple conflicting axes of change:
- Reorganizing physical warehouse aisle/bin navigation logic risks breaking stock allocation math or XML output format.
- Modifying handheld display text templates forces unnecessary edits to inventory calculation logic.
- Changing WMS integration XML schemas contaminates pure inventory allocation and spatial routing concerns.