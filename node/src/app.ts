import { Tree } from './tree.js';

export function app(): number {
  const args = process.argv.slice(2);

  const validateCleanAndFilterArgs = (args: string[]) => {
    const cleanAndFilterArgs = (args: string[]) =>
      args.map((a) => a.trim()).filter((a) => /^\d*$/.test(a));

    if (args.length === 1) {
      return cleanAndFilterArgs(args[0]?.split(','));
    } else {
      return cleanAndFilterArgs(args);
    }
  };

  const cleanArgs = validateCleanAndFilterArgs(args);

  if (cleanArgs.length === 0) {
    console.log('No valid input found, exiting.');
    return 1;
  }

  const tree = new Tree(cleanArgs);

  console.log(tree.walkTree());

  return 0;
}

app();

