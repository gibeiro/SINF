//just something to be here to get on your nerves
Date.prototype.ymd = function() {
    var mm = this.getMonth() + 1; // getMonth() is zero-based
    var dd = this.getDate();

    return '' + this.getFullYear() + (mm>9 ? '' : '0') + mm + (dd>9 ? '' : '0') + dd;
};


function save_processed_data(data){
    var growth_data = [];
    var currentDay = 0;
    var first_date = new Date(date_parts[0],date_parts[1]-1,date_parts[2]);
    for(var i=0 ; i<data.length ; i++){
        while(currentDay!=data[i].day){
            date.setDate(first_date.getDate()+currentDay);
            growth_data.push({day:currentDay, profit:0, date: date.ymd()});
            currentDay++;
        }
        growth_data.push(data[i]);
        currentDay++;
    }
    return growth_data;
}