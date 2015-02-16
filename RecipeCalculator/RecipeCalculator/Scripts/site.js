function formatCurrency(total, decplace) {
    if (total == NaN || total == '' || total == "N/A" || total == null) {
        return '';
    } else {
        var neg = false;
        if (total < 0) {
            neg = true;
            total = Math.abs(total);
        }
        //default 2 decimal place if decplace not supplied. 
        if (parseInt(decplace) == 0) {
            return (neg ? "($" : '$') + parseFloat(total, 10).toFixed().replace(/\B(?=(\d{3})+(?!\d))/g, ",").toString() + (neg ? ")" : "");
        }
        return (neg ? "($" : '$') + parseFloat(total, 10).toFixed(parseInt(decplace) || 2).replace(/(\d)(?=(\d{3})+\.)/g, "$1,").toString() + (neg ? ")" : "");
    }
}