/*
--- Part Two ---

By the time you calculate the answer to the Elves' question, they've already realized that the Elf carrying the most Calories of food might eventually run out of snacks.

To avoid this unacceptable situation, the Elves would instead like to know the total Calories carried by the top three Elves carrying the most Calories. That way, even if one of those Elves runs out of snacks, they still have two backups.

In the example above, the top three Elves are the fourth Elf (with 24000 Calories), then the third Elf (with 11000 Calories), then the fifth Elf (with 10000 Calories). The sum of the Calories carried by these three elves is 45000.

Find the top three Elves carrying the most Calories. How many Calories are those Elves carrying in total?
*/

import { promisify } from 'util'
import { readFile as _readFile } from 'fs'

const readFile = promisify(_readFile)
const inputStr = await readFile('input_one.txt', {encoding: 'utf-8'})

let elfCalorieCounts = []
let iterationTotal = 0

inputStr.split('\n').forEach(line => {
  line = line.trim()
  if (line !== '') {
    iterationTotal += parseInt(line)
  } else {
    elfCalorieCounts.push(iterationTotal)
    iterationTotal = 0
  }
})

elfCalorieCounts.sort((a,b) => b - a)

console.log(elfCalorieCounts.slice(0, 3).reduce((tot, cur) => tot + cur))