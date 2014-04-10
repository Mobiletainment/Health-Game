
var padding = {top: 40, right: 40, bottom: 20, left: 50};
var dataset;
//Set up stack method
var stack = d3.layout.stack();


var w = $("body").width();
var h = $("body").height();

d3.json("mperday.json", function(json) {
    dataset = json;

    //Data, stacked
    stack(dataset);

    var color_hash = {
        0: ["Tägliche Aufgaben", "#1f77b4"],
        1: ["Verhaltensmaßstab", "#2ca02c"],
        2: ["Selbst-Kontrolle", "#ff7f0e"]

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

    var xAxis = d3.svg.axis()
            .scale(xScale)
            .orient("bottom")
            .ticks(dates.length)
            .tickValues(dates.map(function(d) { return d;}))
          //  .ticksValues(xScale.domain.map(function(d) { return d.date;}))
            .tickFormat(d3.time.format("%a"));
            //.tickFormat(d3.time.format("%d"));
    var yAxis = d3.svg.axis()
            .scale(yScale)
            .orient("left")
            .ticks(3)
            .tickFormat(function(d) {
                if (d == 0)
                    return "keine '";
                else
                    return d + " von 3";
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
            .attr("transform", "translate(" + padding.left + "," + (h - padding.bottom) + ")")
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
                return xScale(new Date(d.time));
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
            .attr("transform", "translate(40," + (h - padding.bottom) + ")")
            .call(xAxis);


    svg.append("g")
            .attr("class", "y axis")
            .attr("transform", "translate(" + padding.left + "," + padding.top + ")")
            .call(yAxis);

    // adding legend

    var legend = svg.append("g")
            .attr("class", "legend")
            .attr("x", w - padding.right - 65)
            .attr("y", 25)
            .attr("height", 100)
            .attr("width", 100);

    legend.selectAll("g").data(dataset)
            .enter()
            .append('g')
            .each(function(d, i) {
                var g = d3.select(this);
                g.append("rect")
                        .attr("x", w - padding.right - 65)
                        .attr("y", i * 25 + 10)
                        .attr("width", 10)
                        .attr("height", 10)
                        .style("fill", color_hash[String(i)][1]);

                g.append("text")
                        .attr("x", w - padding.right - 50)
                        .attr("y", i * 25 + 20)
                        .attr("height", 30)
                        .attr("width", 100)
                        .style("fill", color_hash[String(i)][1])
                        .text(color_hash[String(i)][0]);
            });
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
    svg.append("text")
            .attr("class", "title")
            .attr("x", padding.left)
            .attr("y", 20)
            .attr("text-anchor", "left")
            .style("font-size", "16px")
            //.style("text-decoration", "underline")
            .text("Erledigte Tägliche Eingaben der letzten 7 Tage");

    //On click, update with new data			
    d3.selectAll(".m")
            .on("click", function() {
                var date = this.getAttribute("value");

                var str;
                if (date == "2014-02-19") {
                    str = "19.json";
                } else if (date == "2014-02-20") {
                    str = "20.json";
                } else if (date == "2014-02-21") {
                    str = "21.json";
                } else if (date == "2014-02-22") {
                    str = "22.json";
                } else {
                    str = "23.json";
                }

                d3.json(str, function(json) {

                    dataset = json;
                    stack(dataset);

                    console.log(dataset);

                    xScale.domain([new Date(0, 0, 0, dataset[0][0].time, 0, 0, 0), new Date(0, 0, 0, dataset[0][dataset[0].length - 1].time, 0, 0, 0)])
                            .rangeRound([0, w - padding.left - padding.right]);

                    yScale.domain([0,
                        d3.max(dataset, function(d) {
                            return d3.max(d, function(d) {
                                return d.y0 + d.y;
                            });
                        })
                    ])
                            .range([h - padding.bottom - padding.top, 0]);

                    xAxis.scale(xScale)
                            .ticks(d3.time.hour, 2)
                            .tickFormat(d3.time.format("%H"));

                    yAxis.scale(yScale)
                            .orient("left")
                            .ticks(10);

                    groups = svg.selectAll(".rgroups")
                            .data(dataset);

                    groups.enter().append("g")
                            .attr("class", "rgroups")
                            .attr("transform", "translate(" + padding.left + "," + (h - padding.bottom) + ")")
                            .style("fill", function(d, i) {
                                return color(i);
                            });


                    rect = groups.selectAll("rect")
                            .data(function(d) {
                                return d;
                            });

                    rect.enter()
                            .append("rect")
                            .attr("x", w)
                            .attr("width", 1)
                            .style("fill-opacity", 1e-6);

                    rect.transition()
                            .duration(1000)
                            .ease("linear")
                            .attr("x", function(d) {
                                return xScale(new Date(0, 0, 0, d.time, 0, 0, 0));
                            })
                            .attr("y", function(d) {
                                return -(-yScale(d.y0) - yScale(d.y) + (h - padding.top - padding.bottom) * 2);
                            })
                            .attr("height", function(d) {
                                return -yScale(d.y) + (h - padding.top - padding.bottom);
                            })
                            .attr("width", 15)
                            .style("fill-opacity", 1);

                    rect.exit()
                            .transition()
                            .duration(1000)
                            .ease("circle")
                            .attr("x", w)
                            .remove();

                    groups.exit()
                            .transition()
                            .duration(1000)
                            .ease("circle")
                            .attr("x", w)
                            .remove();


                    svg.select(".x.axis")
                            .transition()
                            .duration(1000)
                            .ease("circle")
                            .call(xAxis);

                    svg.select(".y.axis")
                            .transition()
                            .duration(1000)
                            .ease("circle")
                            .call(yAxis);

                    svg.select(".xtext")
                            .text("Hours");

                    svg.select(".title")
                            .text("Number of messages per hour on " + date + ".");
                });
            });


});