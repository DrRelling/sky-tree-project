import { app } from '../build/app';
import { expect, test } from '@jest/globals';

describe('app', () => {
  test('should exit with error if given no input', () => {
    process.argv = [];
    expect(app()).toBe(1);
  });

  test('should exit with error if all inputs are invalid', () => {
    process.argv = ['', '', 'a', 'b'];
    expect(app()).toBe(1);
  });

  test('should accept comma-separated inputs', () => {
    process.argv = ['', '', '1,2,3,4,5'];
    expect(app()).toBe(0);
  });

  test('should accept multiple inputs', () => {
    process.argv = ['', '', '1', '2', '3', '4', '5'];
    expect(app()).toBe(0);
  });
});
