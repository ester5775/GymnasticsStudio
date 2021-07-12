export class Payment {
    
        public Id:number
        public Sum:number=0
        public StudentId:number=0
        public FormOfPayment:string
        public StartDate:string
        public FinishDate:string
        public Balance :number
        constructor(init?: Partial<Payment>) {
            Object.assign(this, init);
        }
}
