﻿#region license
// boo - an extensible programming language for the CLI
// Copyright (C) 2004 Rodrigo B. de Oliveira
//
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.
//
// As a special exception, if you link this library with other files to
// produce an executable, this library does not by itself cause the
// resulting executable to be covered by the GNU General Public License.
// This exception does not however invalidate any other reasons why the
// executable file might be covered by the GNU General Public License.
//
// Contact Information
//
// mailto:rbo@acm.org
#endregion

//
// DO NOT EDIT THIS FILE!
//
// This file was generated automatically by
// astgenerator.boo on 2/25/2004 1:16:55 PM
//

namespace Boo.Lang.Ast.Impl
{
	using System;
	using Boo.Lang.Ast;
	
	[Serializable]
	public abstract class AttributeImpl : Node, INodeWithArguments
	{

		protected string _name;
		protected ExpressionCollection _arguments;
		protected ExpressionPairCollection _namedArguments;

		protected AttributeImpl()
		{
			InitializeFields();
		}
		
		protected AttributeImpl(LexicalInfo info) : base(info)
		{
			InitializeFields();
		}
		

		protected AttributeImpl(string name)
		{
			InitializeFields();
			Name = name;
		}
			
		protected AttributeImpl(LexicalInfo lexicalInfo, string name) : base(lexicalInfo)
		{
			InitializeFields();
			Name = name;
		}
			
		new public Boo.Lang.Ast.Attribute CloneNode()
		{
			return (Boo.Lang.Ast.Attribute)Clone();
		}

		override public NodeType NodeType
		{
			get
			{
				return NodeType.Attribute;
			}
		}
		
		override public void Switch(IAstTransformer transformer, out Node resultingNode)
		{
			Boo.Lang.Ast.Attribute thisNode = (Boo.Lang.Ast.Attribute)this;
			Boo.Lang.Ast.Attribute resultingTypedNode = thisNode;
			transformer.OnAttribute(thisNode, ref resultingTypedNode);
			resultingNode = resultingTypedNode;
		}

		override public bool Replace(Node existing, Node newNode)
		{
			if (base.Replace(existing, newNode))
			{
				return true;
			}

			if (_arguments != null)
			{
				Boo.Lang.Ast.Expression item = existing as Boo.Lang.Ast.Expression;
				if (null != item)
				{
					if (_arguments.Replace(item, (Boo.Lang.Ast.Expression)newNode))
					{
						return true;
					}
				}
			}

			if (_namedArguments != null)
			{
				Boo.Lang.Ast.ExpressionPair item = existing as Boo.Lang.Ast.ExpressionPair;
				if (null != item)
				{
					if (_namedArguments.Replace(item, (Boo.Lang.Ast.ExpressionPair)newNode))
					{
						return true;
					}
				}
			}

			return false;
		}

		override public object Clone()
		{
			Boo.Lang.Ast.Attribute clone = (Boo.Lang.Ast.Attribute)System.Runtime.Serialization.FormatterServices.GetUninitializedObject(typeof(Boo.Lang.Ast.Attribute));
			clone._lexicalInfo = _lexicalInfo;
			clone._documentation = _documentation;
			clone._properties = (System.Collections.Hashtable)_properties.Clone();
			

			clone._name = _name;

			if (null != _arguments)
			{
				clone._arguments = (ExpressionCollection)_arguments.Clone();
			}

			if (null != _namedArguments)
			{
				clone._namedArguments = (ExpressionPairCollection)_namedArguments.Clone();
			}
			
			return clone;
		}
			
		public string Name
		{
			get
			{
				return _name;
			}
			

			set
			{
				_name = value;
			}

		}
		

		public ExpressionCollection Arguments
		{
			get
			{
				return _arguments;
			}
			

			set
			{
				if (_arguments != value)
				{
					_arguments = value;
					if (null != _arguments)
					{
						_arguments.InitializeParent(this);

					}
				}
			}
			

		}
		

		public ExpressionPairCollection NamedArguments
		{
			get
			{
				return _namedArguments;
			}
			

			set
			{
				if (_namedArguments != value)
				{
					_namedArguments = value;
					if (null != _namedArguments)
					{
						_namedArguments.InitializeParent(this);

					}
				}
			}
			

		}
		

		private void InitializeFields()
		{
			_arguments = new ExpressionCollection(this);
			_namedArguments = new ExpressionPairCollection(this);

		}
	}
}
