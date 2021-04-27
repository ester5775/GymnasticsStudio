
export class Student {
    Id: number
    FirstName: string
    LastName: string
    IdentityNumber: string
    PhoneNumber: string
    Pignicher: string
    StudentKind: string
    Balance: number = 0
    CreditDetailsId: number = 0
    Addrees: string
    BirthDay: Date
    HMO: string
    Comments: string
    StartDate: string
    CreditCardNumber: string
    CreditCardValidity: Date
    CreditCardBackDigitis: string
    constructor(init?: Partial<Student>) {
        Object.assign(this, init);
    }
}
