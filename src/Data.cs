using System;

public class Data<T, V, C, D, E>
{
	public T t { get; set;}
	public V v { get; set;}
	public C c { get; set;}
	public D d { get; set;}
	public E e { get; set; }
	public Data(T t,V v,C c,D d,E e)
	{
		this.t = t;
		this.v = v;
		this.c = c;	
		this.d = d;
		this.e = e;
	}
}
