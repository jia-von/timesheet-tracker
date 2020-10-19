import { Doughnut, Bar } from "react-chartjs-2";
import React from "react";

// return the average hours spent per task for each project
const getAverageHoursPerTask = (projects) => {
    let designSum = 0;
    let doingSum = 0;
    let codeReviewSum = 0;
    let testingSum = 0;
    let deliverablesSum = 0;

    for (let project of projects) {
        designSum += project.designHours;
        doingSum += project.doingHours;
        codeReviewSum += project.codeReviewHours;
        testingSum += project.testingHours;
        deliverablesSum += project.deliverablesHours;
    }

    let sumArray = [designSum, doingSum, codeReviewSum, testingSum, deliverablesSum];
    return sumArray.map(value => value / projects.length);

}

// return the max, avg, and min total hours accross a range of projects
const getMAMForProjects = (projects) => {
    let maxHours = projects.length > 0 ? projects[0].totalHours : 0; //this will be replaced by a higher value in for loop if one exists
    let minHours = projects.length > 0 ? projects[0].totalHours : 0; // this will be replaced by a lower value in for loop if one exists
    let avgHours = 0;
    let totalHoursSum = 0;

    for (let project of projects) {
        if (project.totalHours > maxHours) {
            maxHours = project.totalHours;
        } else if (project.totalHours < minHours) {
            minHours = project.totalHours;
        }

        totalHoursSum += project.totalHours;
    }

    avgHours = totalHoursSum / projects.length;
    return [maxHours, avgHours, minHours];
}

// return an array of time intervals and students who fall into them
// eg [0-1hr, 1-2hr, ... ] and [3, 4,...]
const getLabelsAndFrequency = (projects) => {
    let intervalCount = 5;
    let labels = [];
    let frequency = Array(intervalCount + 2).fill(0); //create default array
    let maxHours = projects.length > 0 ? projects[0].totalHours : 0; //this will be replaced by a higher value in for loop if one exists
    let minHours = projects.length > 0 ? projects[0].totalHours : 0; // this will be replaced by a lower value in for loop if one exists

    // get the max and min
    for (let project of projects) {
        if (project.totalHours > maxHours) {
            maxHours = project.totalHours;
        } else if (project.totalHours < minHours) {
            minHours = project.totalHours;
        }
    }

    let hourRange = maxHours - minHours;
    let hourInterval = hourRange / intervalCount;

    // add the labels 
    let counter = minHours - hourInterval;
    for (let index in frequency) {
        labels[index] = `${counter.toFixed(2)} to ${(counter + hourInterval).toFixed(2)}`;
        counter += hourInterval; // increment the counter
    }

    // if hour interval is 0, frequency array remains an array of 0 values
    if (hourInterval !== 0) {
        // populate the frequency array with the number of students who fall into a time interval
        for (let project of projects) {
            // determine where this project will fall in our range of values
            let index = Math.floor((project.totalHours - minHours) / hourInterval) + 1;
            // increment the index by 1
            frequency[index] += 1;
        }
    }

    //return the labels and frequency arrays
    return [labels, frequency];
}

// return an array of projects which match the filter name
const filterProjectsByName = (projectName, projects) => {
    return projects.filter(project => project.projectName.trim().toLowerCase() === projectName.trim().toLowerCase() );
}

// return an array of projects which match the cohort
const  filterProjectsByCohort = (cohort, projects) => {
    return projects.filter(project => project.cohort == cohort);
}


// return a doughnut chart
const renderDoughnut = (projectData, filterName, cohort) => {
    // if a name filter is provided, filter the project list, else use unfiltered projects
    let filteredData = filterName.trim() === "" ? projectData : filterProjectsByName(filterName, projectData);
    filteredData = cohort === "" ? filteredData : filterProjectsByCohort(cohort, filteredData);

    let colors = [
        'rgba(98, 169, 255, .75)', //blue
        'rgba(132, 94, 194, .75)', //purple
        'rgba(0, 143, 122, .75)', //green
        'rgba(255, 150, 113, .75)', //orange
        'rgba(201, 0, 0, .75)' //red
    ];

    let data = {
        labels: ["Design", "Doing", "Code Review", "Testing", "Deliverables"],
        datasets: [{
            label: "Hours",
            backgroundColor: colors,
            borderColor: 'rgba(255, 255, 255, 1)',
            borderWidth: 2,
            data: getAverageHoursPerTask(filteredData)
        }]
    };

    let options = {
        legend: {
            labels: {
                boxWidth: 20
            }
        }
    }

    return < Doughnut data={data} options={options} />;
}

// return a bar chart
const renderBar = (projectData, filterName, cohort) => {
    // if a name filter is provided, filter the project list, else use unfiltered projects
    let filteredData = filterName.trim() === "" ? projectData : filterProjectsByName(filterName, projectData);
    filteredData = cohort === "" ? filteredData : filterProjectsByCohort(cohort, filteredData);

    let data = {
        labels: ["Maximum", "Average", "Minimum"],
        datasets: [{
            label: "Total Hours",
            backgroundColor: 'rgba(153, 206, 255, .75)',
            borderColor: 'rgba(0, 103, 200, .90)',
            borderWidth: 2,
            data: getMAMForProjects(filteredData)
        }]
    };

    let options = {
        legend: {
            labels: {
                boxWidth: 10
            }
        }
    }

    return < Bar data={data} options={options} />;
}

const renderHistogram = (projectData, filterName, cohort) => {
    // if a name filter is provided, filter the project list, else use unfiltered projects
    let filteredData = filterName.trim() === "" ? projectData : filterProjectsByName(filterName, projectData);
    filteredData = cohort === "" ? filteredData : filterProjectsByCohort(cohort, filteredData);
    let dataArray = getLabelsAndFrequency(filteredData);

    let data = {
        labels: dataArray[0],
        datasets: [{
            label: "Frequency",
            backgroundColor: 'rgba(153, 206, 255, .75)',
            borderColor: 'rgba(0, 103, 200, .90)',
            borderWidth: 2,
            data: dataArray[1]
        }]
    };

    let options = {
        legend: {
            labels: {
                boxWidth: 10
            }
        }
    }

    return < Bar data={data} options={options} />;
}

export { renderDoughnut, renderBar, renderHistogram };