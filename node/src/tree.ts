import { TreeNode } from './treeNode.js';

export class Tree {
  private _rootNode?: TreeNode;
  public get rootNode() {
    return this._rootNode;
  }

  constructor(inputs: any[]) {
    if (inputs.length === 0) {
      return;
    }

    this._rootNode = new TreeNode(inputs.shift());

    this.buildTree(inputs);
  }

  public walkTree(): TreeNode[] {
    if (this.rootNode == null) {
      return [];
    }

    const nodes: TreeNode[] = [];
    const unexpandedNodes: TreeNode[] = [this.rootNode];

    while (unexpandedNodes.length > 0) {
      const nextNode = unexpandedNodes.pop();
      if (nextNode != null) {
        nodes.push(nextNode);
        unexpandedNodes.push(...nextNode.children);
      }
    }

    return nodes.map((n) => n.value).reverse();
  }

  private buildTree(inputs: any[]): void {
    const parents = [this.rootNode];

    while (inputs.length > 0) {
      const nextParent = parents.shift();
      if (nextParent != null) {
        const newChildren = [inputs.shift(), inputs.shift()]
          .filter((c) => c != null)
          .map((c) => new TreeNode(c, nextParent));
        nextParent.children.push(...newChildren);

        parents.push(...nextParent.children);
      }
    }
  }
}
