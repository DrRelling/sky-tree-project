export class TreeNode {
  public value: any;

  public children: TreeNode[] = [];

  public parent?: TreeNode;

  constructor(value: any, parent?: TreeNode) {
    this.value = value;
    this.parent = parent;
  }
}