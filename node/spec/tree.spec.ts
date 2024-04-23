import { expect, test } from '@jest/globals';
import { Tree } from '../build/tree';

describe('tree', () => {
  test('should return expected output from example', () => {
    const tree = new Tree(['15', '10', '22', '4', '12', '18', '24']);
    expect(tree.walkTree()).toEqual(['4', '12', '10', '18', '24', '22', '15']);
  });

  test('should create a balanced tree', () => {
    const tree = new Tree([1, 2, 3, 4, 5, 6, 7]);
    expect(tree.walkTree()).toEqual([4, 5, 2, 6, 7, 3, 1]);
  });

  test('should create an unbalanced tree', () => {
    const tree = new Tree([1, 2, 3, 4, 5, 6]);
    expect(tree.walkTree()).toEqual([4, 5, 2, 6, 3, 1]);
  });

  test('should return an empty array if given nothing', () => {
    const tree = new Tree([]);
    expect(tree.walkTree()).toEqual([]);
  });
});
