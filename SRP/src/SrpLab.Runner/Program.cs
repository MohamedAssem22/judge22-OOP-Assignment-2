using SrpLab;
using SrpLab.GradeBook;
using SrpLab.LoanManager;
using SrpLab.KitchenTicket;
using SrpLab.Appointment;
Console.WriteLine("SrpLab — 10 refactored classes adhering to SRP");
Console.WriteLine("=============================================");

// 1. WardBoard
var ward = new WardBoard();
ward.AssignBed(1, "p-88", heartRate: 130, spo2: 89);
Console.WriteLine(ward.BuildHandoffNote(1));
Console.WriteLine(string.Join(" | ", ward.DrainPagerLog()));

// 2. CheckoutBasket
var basket = new CheckoutBaskett();
basket.AddLine("SKU-1", 40m, 2);
basket.ApplyCouponText("SAVE10");
basket.EnableGiftWrap();
Console.WriteLine($"basket total={basket.GrandTotal()} auth={basket.AuthorizePaymentStub("4242")}");

// 3. SupportTicket
var ticket = new SupportTicket("T-1", "cannot login", "prod is down for me", DateTimeOffset.UtcNow);
Console.WriteLine(ticket.DraftPublicReply("Nora"));

// 4. LoanDesk
var loan = new LoanManager(60_000m, 640, 4, hasCollateral: false);
Console.WriteLine(loan.DecisionLetter("Omar"));

// 5. CourseEnrollmentDesk
var course = new CourseEnrollmentManager("SEF-101", capacity: 1, tuition: 3000m);
Console.WriteLine(course.Register("a@mail.com"));
Console.WriteLine(course.Register("b@mail.com"));
Console.WriteLine(course.WelcomePacketMarkdown("b@mail.com", "Bea"));

// 6. KitchenTicket
var kitchen = new KitchenTicket();
kitchen.AddItem("Pasta", new[] { "wheat", "milk" }, 12);
Console.WriteLine(kitchen.RenderThermalTicket(42));

// 7. SubscriptionBilling
var sub = new SubscriptionBilling("c-9", 99m, new DateOnly(2026, 9, 1), new DateOnly(2026, 10, 1));
sub.RegisterFailedPayment();
Console.WriteLine(sub.DunningEmail("Sara", new DateOnly(2026, 9, 20)));

// 8. WarehousePickList
var pick = new WarehousePickList();
pick.AddNeed("BOLT", "A", 3, 10, 7);
pick.AddNeed("NUT", "B", 1, 5, 5);
Console.WriteLine(pick.PickerScript());

// 9. GradeBook
var grades = new GradeBook();
grades.Record("s1", 92);
grades.Record("s1", 88);
Console.WriteLine(grades.TranscriptPlain("s1", "Ali"));




Console.WriteLine("SrpLab — Appointment Module Test");
Console.WriteLine("==================================");

var policy = new OperatingHoursPolicy(new TimeOnly(9, 0), new TimeOnly(17, 0), 30);


var appt = new AppointmentScheduler(policy);


var slot = appt.FindNextSlot(DateTimeOffset.Parse("2026-09-21T08:00:00Z"), 48);
if (slot is null) throw new InvalidOperationException("no slot");

appt.TryBook(slot.Value);


var reminderFormatter = new SmsReminderFormatter();
Console.WriteLine(reminderFormatter.SmsReminder(slot.Value, "0100"));

var icsExporter = new IcsCalendarExporter();
Console.WriteLine(icsExporter.ToIcs(slot.Value, policy.SlotMinutes, "Ahmed", "Dr. Smith"));

Console.WriteLine("Appointment module executed successfully!");