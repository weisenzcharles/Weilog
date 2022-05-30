package org.charles.weilog.service;

import org.charles.weilog.domain.Posts;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.Pageable;

import java.util.List;

public interface PostService {
//    Page<Post> listPost(Pageable pageable, PostQuery post);

    Page<Posts> listPost(Pageable pageable);

    Page<Posts> listPost(Pageable pageable, String query);

    boolean add(Posts tag);

    boolean remove(Long id);

    boolean update(Posts tag);

    Posts query(Long id);

    List<Posts> query(String title, int pageIndex, int pageSize);

    List<Posts> query(int pageIndex, int pageSize);
}
