
var padding = {top: 30, right: 120, bottom: 100, left: 50};
var dataset;
//Set up stack method
var stack = d3.layout.stack();
var offsetX = 135;

var w = $("body").width();
var h = $("body").height();
var numberOfStacks = 5;

d3.json("statisticsDailyTasks.json", function(json) {
    dataset = json;

    //Data, stacked
    stack(dataset);

    var color_hash = {
        0: ["Weniger fernsehen", "#7b3294"],
        1: ["Bett machen", "#e7298a"],
        2: ["Schultasche packen", "#4575b4"],
        3: ["Hausaufgaben machen", "#4daf4a"],
        4: ["Zähne putzen", "#d95f02"]
  

    };

    var dates = [];

    dataset[0].forEach(function(obj)
    {
        dates.push(new Date(obj.time));
    });


    //Set up scales
    var xScale = d3.time.scale()
            .domain([dates[0], d3.time.day.offset(dates[dates.length - 1], 1)])
            .rangeRound([0, w - padding.left - padding.right]);

    var yScale = d3.scale.linear()
            .domain([0,
                d3.max(dataset, function(d) {
                    return d3.max(d, function(d) {
                        return d.y0 + d.y;
                    });
                })
            ])
            .range([h - padding.bottom - padding.top, 0]);

    var parseDate = d3.time.format("%a").parse;

    var xAxis = d3.svg.axis()
            .scale(xScale)
            .orient("bottom")
            .ticks(dates.length)
            .tickValues(dates.map(function(d) {
                return d;
            }))
            //  .ticksValues(xScale.domain.map(function(d) { return d.date;}))

            .tickFormat(function(d) {
                switch (d.getDay())
                {
                    case 0:
                        return "So.";
                    case 1:
                        return "Mo.";
                    case 2:
                        return "Di.";
                    case 3:
                        return "Mi.";
                    case 4:
                        return "Do.";
                    case 5:
                        return "Fr.";
                    case 6:
                        return "Sa.";
                    default:
                        return d;
                }
            });
    //.tickFormat(d3.time.format("%d"));
    var yAxis = d3.svg.axis()
            .scale(yScale)
            .orient("left")
            .ticks(numberOfStacks)
            .tickFormat(function(d) {
                if (d == 0)
                    return "keine";
                else if (d === 1)
                    return "20%";
                else if (d === 2)
                    return "40%";
                else if (d === 3)
                    return "60%";
                else if (d === 4)
                    return "80%";
                else
                    return "100%";
            });



    //Easy colors accessible via a 10-step ordinal scale
    var colors = d3.scale.category10();



    //Create SVG element
    var svg = d3.select("#mbars")
            .append("svg")
            .attr("preserveAspectRatio", "xMidYMid")
            .attr("viewBox", "0 0 " + w + " " + h)
            .attr("width", w)
            .attr("height", h);

    $(window).resize(function() {
        var width = $("body").width();
        svg.attr("width", width);

        var height = $("body").height();

        svg.attr("height", height);
    });


    // Add a group for each row of data
    var groups = svg.selectAll("g")
            .data(dataset)
            .enter()
            .append("g")
            .attr("class", "rgroups")
            .attr("transform", "translate(" + (padding.left + offsetX) + "," + (h - padding.bottom) + ")")
            .style("fill", function(d, i) {
                return color_hash[dataset.indexOf(d)][1];
            });

    // Add a rect for each data value
    var rects = groups.selectAll("rect")
            .data(function(d) {
                return d;
            })
            .enter()
            .append("rect")
            .attr("width", 2)
            .style("fill-opacity", 1e-6);


    rects.transition()
            .duration(function(d, i) {
                return 500 * i;
            })
            .ease("linear")
            .attr("x", function(d) {
                return xScale(new Date(d.time)) + 3;
            })
            .attr("y", function(d) {
                return -(-yScale(d.y0) - yScale(d.y) + (h - padding.top - padding.bottom) * 2);
            })
            .attr("height", function(d) {
                return -yScale(d.y) + (h - padding.top - padding.bottom);
            })
            .attr("width", 15)
            .style("fill-opacity", 1);

    svg.append("g")
            .attr("class", "x axis")
            .attr("transform", "translate(" + (60 + offsetX) + "," + (h - padding.bottom) + ")")
            .call(xAxis);


    svg.append("g")
            .attr("class", "y axis")
            .attr("transform", "translate(" + (padding.left + offsetX) + "," + padding.top + ")")
            .call(yAxis);
    svg.append("svg:line")
            .attr("x1", padding.left - 0 + offsetX)
            .attr("y1", padding.top)
            .attr("x2", w)
            .attr("y2", padding.top)
            .style("stroke", "#111")
            .style("stroke-width", 2)
            .style("stroke-dasharray", ("3, 3"));

     svg.append("g").append("text")
            .attr("class", "legend")
            .attr("x", (padding.left + w + padding.right) / 2)
            .attr("y", padding.top - 2)
            .attr("height", 30)
            .attr("width", 100)
            .style("font-weight", "bolder")
            .text("Ziel");

    // adding legend



    var legend = svg.append("g")
            .attr("class", "legend")
            .attr("x", padding.left)
            .attr("y", 45)
            .attr("height", 100)
            .attr("width", 100);
 

    legend.selectAll("g").data(dataset)
            .enter()
            .append('g')
            .each(function(d, i) {
                var g = d3.select(this);
                g.append("rect")
                        .attr("x", 0)
                        .attr("y", i * 25 + 30)
                        .attr("width", 10)
                        .attr("height", 10)
                        .style("fill", color_hash[String(numberOfStacks-1-i)][1]);

                g.append("text")
                        .attr("x", 12)
                        .attr("y", i * 25 + 39)
                        .attr("height", 30)
                        .attr("width", 100)
                        .style("fill", color_hash[String(numberOfStacks-1-i)][1])
                        .text(color_hash[String(numberOfStacks-1-i)][0]);
            });
            
       legend.append("g").append("text")
            .attr("x", 0)
            .attr("y", 20)
            .attr("height", 0)
            .attr("width", 100)
            .style("font-weight", "bolder")
            .text("Erledigte Aufgaben:");
    
       legend.attr("transform", "translate(" + 10 + ",15)");
    /*
     svg.append("text")
     .attr("transform", "rotate(-90)")
     .attr("y", 0 - 5)
     .attr("x", 0 - (h / 2))
     .attr("dy", "1em")
     .text("Eingaben erledigt");
     
     svg.append("text")
     .attr("class", "xtext")
     .attr("x", w / 2 - padding.left)
     .attr("y", h - 5)
     .attr("text-anchor", "middle")
     .text("Der letzten 7 Tage");
     */
    function navigateBack()
    {
        window.history.back();
    }
    /*
     var hyperlink = svg.append("svg:a");
     
     hyperlink.on("click", navigateBack);
     hyperlink.append("svg:image")
     .attr('x', 10)
     .attr('y', 4)
     .attr('width', 20)
     .attr('height', 20)
     .attr("xlink:href", "css/jquery.mobile/images/icons-png/arrow-l-black.png");
     hyperlink.append("text")
     .attr("x", 30)
     .attr("y", 20)
     .attr("text-anchor", "left")
     .style("font-size", "16px")
     //.style("text-decoration", "underline")
     .text('Zurück');
     */

    /*
     svg.append("text")
     .attr("class", "title")
     .attr("x", 90)
     .attr("y", 20)
     .attr("text-anchor", "left")
     .style("font-size", "16px")
     //.style("text-decoration", "underline")
     .text('Erledigte Tägliche Eingaben der letzten 7 Tage');
     */
    //On click, update with new data			
  
});