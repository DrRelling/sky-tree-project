import chalk from 'chalk';
import { Tree } from './tree';

export function app(): void {
  const args = process.argv.slice(2);

  const validateCleanAndFilterArgs = (args: string[]) => {
    const cleanAndFilterArgs = (args: string[]) =>
      args.map((a) => a.trim()).filter((a) => /^\d*/.test(a));

    if (args.length === 1) {
      return cleanAndFilterArgs(args[0]?.split(','));
    } else {
      return cleanAndFilterArgs(args);
    }
  };

  const cleanArgs = validateCleanAndFilterArgs(args);

  if (cleanArgs.length === 0) {
    console.log(chalk.red('No valid input found, exiting.'));
    process.exit(1);
  }

  const tree = new Tree(cleanArgs);

  console.log(tree.walkTree());

  process.exit(0);
}

app();
