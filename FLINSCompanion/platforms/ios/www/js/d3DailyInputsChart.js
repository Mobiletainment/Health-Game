var w = $("body").width();
var h = $("body").height() - 120;

var maxValues = 14;

var monthNames = ["Jänner", "Februar", "März", "April", "May", "June",
    "July", "August", "September", "October", "November", "December"];

var maxDataPointsForDots = 50,
        transitionDuration = 1000;

var svg = null,
        yAxisGroup = null,
        xAxisGroup = null,
        dataCirclesGroup = null,
        dataLinesGroup = null;

function draw() {
    var data = generateData();
    var marginTopBottom = 40;
    var marginLeftRight = 35;
    var max = d3.max(data, function(d) {
        return d.value
    });
    var min = 0;
    var pointRadius = 4.0;
    var x = d3.time.scale().range([0, w - marginLeftRight * 2]).domain([data[0].date, data[data.length - 1].date]);
    var y = d3.scale.linear().range([h - marginTopBottom * 2, 0]).domain([min, max]);
    
    var xAxis = d3.svg.axis()
            .scale(x)
            .tickSize(h - marginTopBottom * 2)
            .tickPadding(10)
            .ticks(maxValues)
            .tickFormat(function(d) {
                return d.getDate() + "." + (d.getMonth() + 1);
                
            });
    var xAxis2 = d3.svg.axis()
            .scale(x)
            .tickSize(h - marginTopBottom * 2)
            .tickPadding(10)
            .ticks(maxValues)
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

    var yAxis = d3.svg.axis()
            .scale(y).orient('left')
            .tickSize(-w + marginLeftRight * 2).tickPadding(10)
            .ticks(3)
            .tickFormat(function(d) {
                if (d === 0)
                    return "keine";
                return d + " von 3";
            });
    var t = null;


    svg = d3.select('#chart').select('svg').select('g');
    if (svg.empty()) {
        svg = d3.select('#chart')
                .append('svg:svg')
                .attr('width', w)
                .attr('height', h)
                .attr('class', 'viz')
                .append('svg:g')
                .attr('transform', 'translate(' + (marginLeftRight+22) + ',' + (marginTopBottom - 10) + ')');

                


        var gradient = svg.append("svg:defs")
                .append("svg:linearGradient")
                .attr("id", "ProblemGradient")
                .attr("gradientUnits", "userSpaceOnUse")    
        .attr("x1", 0).attr("y1", y(0))         
        .attr("x2", 0).attr("y2", y(3))      
    .selectAll("stop")                      
        .data([                             
            {offset: "0%", color: "#b92928"},       
            {offset: "40%", color: "red"},  
            {offset: "40%", color: "red"},        
            {offset: "80%", color: "red"},        
            {offset: "95%", color: "#12b725"},  
            {offset: "100%", color: "#66cc00"}    
        ])                  
    .enter().append("stop")         
        .attr("offset", function(d) { return d.offset; })   
        .attr("stop-color", function(d) { return d.color; }); 


    }

    

    t = svg.transition().duration(transitionDuration);

    // y ticks and labels
    if (!yAxisGroup) {
        yAxisGroup = svg.append('svg:g')
                .attr('class', 'yTick')
                .call(yAxis);
    }
    else {
        t.select('.yTick').call(yAxis);
    }

    // x ticks and labels
    if (!xAxisGroup) {
        xAxisGroup = svg.append('svg:g')
                .attr('class', 'xTick')
                .attr("transform", "translate(0,9)")
                .call(xAxis);
        
        svg.append('svg:g')
                .attr('class', 'xTick')
                .attr("transform", "translate(" + 2 + ",0)")
                .call(xAxis2);
                
    }
    else {
        t.select('.xTick').call(xAxis);
    }

    // Draw the lines
    if (!dataLinesGroup) {
        dataLinesGroup = svg.append('svg:g');
    }

    var dataLines = dataLinesGroup.selectAll('.data-line')
            .data([data]);

    var line = d3.svg.line()
            // assign the X function to plot our line as we wish
            .x(function(d, i) {
                // verbose logging to show what's actually being done
                //console.log('Plotting X value for date: ' + d.date + ' using index: ' + i + ' to be at: ' + x(d.date) + ' using our xScale.');
                // return the X coordinate where we want to plot this datapoint
                //return x(i); 
                return x(d.date);
            })
            .y(function(d) {
                // verbose logging to show what's actually being done
                //console.log('Plotting Y value for data value: ' + d.value + ' to be at: ' + y(d.value) + " using our yScale.");
                // return the Y coordinate where we want to plot this datapoint
                //return y(d); 
                return y(d.value);
            })
            .interpolate("linear");

            //Goal line
    svg.append("line")
            .attr("x1", 0)
            .attr("y1", 0)
            .attr("x2", w - marginLeftRight * 2)
            .attr("y2", 0)
            .style("stroke", "#111")
            .style("stroke-width", 2)
            .style("stroke-dasharray", ("3, 3"));
    
    
    svg.append("line")
            .attr("class", "line")
            .attr("x1", 0)
            .attr("y1", h - marginTopBottom * 2)
            .attr("x2", w - marginLeftRight * 2)
            .attr("y2", h - marginTopBottom * 2)
            .style("stroke", "#000")
            .style("stroke-width", 0.4);

    /*
     .attr("d", d3.svg.line()
     .x(function(d) { return x(d.date); })
     .y(function(d) { return y(0); }))
     .transition()
     .delay(transitionDuration / 2)
     .duration(transitionDuration)
     .style('opacity', 1)
     .attr("transform", function(d) { return "translate(" + x(d.date) + "," + y(d.value) + ")"; });
     */

    var garea = d3.svg.area()
            .interpolate("linear")
            .x(function(d) {
                // verbose logging to show what's actually being done
                return x(d.date);
            })
            .y0(h - marginTopBottom * 2)
            .y1(function(d) {
                // verbose logging to show what's actually being done
                return y(d.value);
            });

    dataLines
            .enter()
            .append('svg:path')
            .attr("class", "area")
           // .style("fill", "url(#ProblemGradient)")
            .attr("d", garea(data));

    dataLines.enter().append('path')
            .attr('class', 'data-line')
            .style('opacity', 0.3)
            .attr("d", line(data));
    /*
     .transition()
     .delay(transitionDuration / 2)
     .duration(transitionDuration)
     .style('opacity', 1)
     .attr('x1', function(d, i) { return (i > 0) ? xScale(data[i - 1].date) : xScale(d.date); })
     .attr('y1', function(d, i) { return (i > 0) ? yScale(data[i - 1].value) : yScale(d.value); })
     .attr('x2', function(d) { return xScale(d.date); })
     .attr('y2', function(d) { return yScale(d.value); });
     */

    dataLines.transition()
            .attr("d", line)
            .duration(transitionDuration)
            .style('opacity', 1)
            .attr("transform", function(d) {
                return "translate(" + x(d.date) + "," + y(d.value) + ")";
            });

    dataLines.exit()
            .transition()
            .attr("d", line)
            .duration(transitionDuration)
            .attr("transform", function(d) {
                return "translate(" + x(d.date) + "," + y(0) + ")";
            })
            .style('opacity', 1e-6)
            .remove();

    d3.selectAll(".area").transition()
            .duration(transitionDuration)
            .attr("d", garea(data));

   

    // Draw the points
    if (!dataCirclesGroup) {
        dataCirclesGroup = svg.append('svg:g');
    }

    var circles = dataCirclesGroup.selectAll('.data-point')
            .data(data);

    circles
            .enter()
            .append('svg:circle')
            .attr('class', 'data-point')
           /*
            .style('stroke', function(d)
                { 
                    console.log(d.value);
                    if (d.value === 3)
                        return '#12b725';
                    else
                        return '#b92928';
                })
            */
            .style('opacity', 1e-6)
            .attr('cx', function(d) {
                return x(d.date)
            })
            .attr('cy', function() {
                return y(0)
            })
            .attr('r', function(d) {
             
                return (data.length <= maxDataPointsForDots) ? pointRadius : 0;
            })
            .style('stroke', function(d)
                { 
                    console.log(d.value);
                    if (d.value === 3)
                        return '#12b725';
                    else
                        return '#b92928';
                })
            .transition()
            .duration(transitionDuration)
            .style('opacity', 1)
    
            .attr('cx', function(d) {
                return x(d.date)
            })
            .attr('cy', function(d) {
                return y(d.value)
            });

    circles
            .transition()
            .duration(transitionDuration)
            .attr('cx', function(d) {
                return x(d.date)
            })
            .attr('cy', function(d) {
                return y(d.value)
            })
            .attr('r', function(d) {
                 if (d.value === 3)
                    return 4;
                return (data.length <= maxDataPointsForDots) ? pointRadius : 0
            })
            .style('opacity', 1);

    circles
            .exit()
            .transition()
            .duration(transitionDuration)
            // Leave the cx transition off. Allowing the points to fall where they lie is best.
            //.attr('cx', function(d, i) { return xScale(i) })
            .attr('cy', function() {
                return y(0)
            })
            .style("opacity", 1e-6)
            .remove();

    svg.append("g").append("text")
            .attr("class", "goal")
            .attr("x", (w+12-2*marginLeftRight)/2)
            .attr("y", -3)
            .attr("text-anchor", "middle")
            .attr("height", 30)
            .attr("width", 100)
            .style("font-size", "12px")
            .style("font-weight", "bolder")
            .style("fill", "#000")
            .text("Ziel");
/*
    var legend = svg.append("g")
            .attr("class", "legend")
            .attr("x", 0)
            .attr("y", 0)
            .attr("height", 100)
            .attr("width", 100);


    legend.append("rect")
            .attr("x", 0)
            .attr("y", 0)
            .attr("width", 10)
            .attr("height", 10)
            .style("fill", "#12b725");

    legend.append("text")
            .attr("class", "legend")
            .attr("x", 12)
            .attr("y", 9)
            .style("fill", "#12b725")
            .text("Alle Eingaben erledigt");

    legend.append("rect")
            .attr("x", 0)
            .attr("y", 15)
            .attr("width", 10)
            .attr("height", 10)
            .style("fill", "#b92928");

    legend.append("text")
            .attr("class", "legend")
            .attr("x", 12)
            .attr("y", 24)
            .style("fill", "#b92928")
            .text("Keine oder nicht alle erledigt");


    legend.attr("transform", "translate(" + 0 + ",-35)");
*/
/*
    $('svg circle').tipsy({
        gravity: 'w',
        html: true,
        title: function() {
            var d = this.__data__;
            var pDate = d.date;
            return 'Date: ' + pDate.getDate() + " " + monthNames[pDate.getMonth()] + " " + pDate.getFullYear() + '<br>Value: ' + d.value;
        }
    });
    */
}

function generateData() {
    var data = [];
    var i = maxValues;

    var values = [0, 1, 2, 3, 0, 3, 3, 3, 0, 0, 0, 3, 3, 3, 3,3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3];

    while (i--) {
        var date = new Date();
        date.setDate(date.getDate() - 28 - i);
        date.setHours(0, 0, 0, 0);
        //data.push({'value': Math.round(Math.random() * 3), 'date': date});
        data.push({'value': values[maxValues - i], 'date': date});
    }
    
    data[0].value = 0;
    
    return data;
}

draw();