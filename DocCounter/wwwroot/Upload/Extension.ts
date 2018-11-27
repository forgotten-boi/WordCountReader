
interface Date {
    ConvertToDateFromTS(msg: string): Date;
}

Date.prototype.ConvertToDateFromTS = function(msg: string): any {
    // implement logic
}

let oldDate = new Date();
let newDate = oldDate.ConvertToDateFromTS("10-12-2017");
console.log(newDate)